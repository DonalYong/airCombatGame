using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using LitJson;
using UnityEngine;

//jsonReader["plannes"][0]["planeId"].Get<int>(()=>)
public class JsonReader : IReader
{
    private JsonData _data;
    private JsonData _tempData;//缓存JsonData本身的值一遍继续返回JSONDsta的内容
    private KeyQueue _keys;//保存当前key只队列
    private Queue<KeyQueue> _keyQueues = new Queue<KeyQueue>();

    //索引器
    public IReader this[string key]
    {
       get 
        {
            //if (_data == null)//没加载完成情况
            //{
            //    if (_keys == null)
            //        _keys = new KeyQueue();
            //    Ikey keyData = new Key();
            //    keyData.Set(key);
            //    _keys.Enqueue(keyData);

            //    return this;
            //}
            //_tempData = _tempData[key];
            if (!SetKey(key))
            {
                _tempData = _tempData[key];
            }
            return this;
         }
    }

    public IReader this[int key]
    {
        get
        {
            if (!SetKey(key))
            {
                _tempData = _tempData[key];
             }
            return this;
        }
    }

    //Data没有加载好，需要进行数据缓存，在缓存的过程中可能会出现当前的data调用了一部分但是当前这一组缓存还没执行完，如果光判断data是否等于空，可能后面的key值就加不进去了
    private bool SetKey<T>(T key)
    {
        if (_data == null||_keys!=null)//没加载完成情况
        {
            if (_keys == null)
                _keys = new KeyQueue();
            Ikey keyData = new Key();
            keyData.Set(key);
            _keys.Enqueue(keyData);
            return true;

        }
        return false;
    }

    //回调传值
    public void Get<T>(Action<T> callBack)
    {
        if(_keys!=null)//当前是有缓存的key值
        {
            _keys.OnComplete((dataTemp) => {
                T value = GetValue<T>(dataTemp);
                callBack(value);
                ResetData();
            });
            _keyQueues.Enqueue(_keys);
            _keys = null;
            ExecuteKeysQueue();//执行缓存
            return;
        }
        if (callBack == null)
        {
            Debug.LogWarning("当前回调方法为空，不返回数据");

            ResetData();
            return;
        }
        T data = GetValue<T>(_tempData);
        callBack(data);
        ResetData();
    }
    private void ExecuteKeysQueue()
    {
        if (_data == null)
            return;

        IReader reader =null;
        foreach (KeyQueue keyQueue in _keyQueues)
        {
            foreach (object value in keyQueue)
            {
                if(value is string)
                {
                    reader = this[(string)value];
                }
                else if(value is int)
                {
                    reader = this[(int)value];
                }
                else
                {
                    Debug.LogError("当前键值类型错误");
                }
                
            }
            keyQueue.Complete(_tempData);
        }
    }

    //获得到具体值
    private T GetValue<T>(JsonData data)
    {
        //泛型类型转换先转object再转T
        var converter = TypeDescriptor.GetConverter(typeof(T));
        return (T)converter.ConvertTo(data.ToJson(), typeof(T));
    }
    private void ResetData()
    {
        _tempData = _data;
    }

   //设置数据
    public void SetData(object data)
    {
        if (data is string)
        {
            _data = JsonMapper.ToObject(data as string);//返回JsonData
            ResetData();
            ExecuteKeysQueue();
        }
        else
        {
            Debug.LogError("当前传入数据类型错误，当前只能解析json");
        }
    }
}

//key值的缓存队列
public class KeyQueue: IEnumerable//在使用foreach进行遍历时需要该对象实现IEnumerable接口
{
    private Queue<Ikey> _keys = new Queue<Ikey>();
    private Action<JsonData> _complete;
    //保存key的方法
    public void Enqueue(Ikey key)
    {
        _keys.Enqueue(key);

    }
    //移除当前key方法
    public void Dequeue()
    {
        _keys.Dequeue();
    }
    //清除
    public void Clear()
    {
        _keys.Clear();
    }

    //回调继续缓存
    public void Complete(JsonData data)
    {
        if (_complete != null)
            _complete(data);
    }
    public void OnComplete(Action<JsonData> complete)
    {
        _complete = complete;
    }
    //遍历并返回key
    public IEnumerator GetEnumerator()
    {
        foreach(Ikey key in _keys)
        {
            yield return key.Get();
        }
    }
}
public interface Ikey
{
    void Set<T>(T key);
    object Get();
    Type KeyType { get; }
}
public class Key : Ikey
{
    private object _key;
    public Type KeyType { get; private set; }
    public void Set<T1>(T1 key) 
    {
        _key = key;
    }
    public object Get() 
    {
        return _key;
    }

    
}
