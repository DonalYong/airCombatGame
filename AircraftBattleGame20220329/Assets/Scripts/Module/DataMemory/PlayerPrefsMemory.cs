using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

/*PlayerPrefsl类是Unity3d提供了一个用于数据本地持久化保存与读取的类，以key-value的形式将数据保存在本地，然后在代码中可以写入、读取、更新数据。
1.存储数据
    //存储整型数据
    PlayerPrefs.SetInt("intKey", 999);

    //存储浮点型数据
    PlayerPrefs.SetFloat("floatKey", 1.11f);

    //存储字符串数据
    PlayerPrefs.SetString("strKey", "I am Plane");
2.取出数据：
    //取出key为"intKey"的整型数据
    int intVal = PlayerPrefs.GetInt("intKey");

    //取出key为"floatKey"的浮点型数据
    float floatVal = PlayerPrefs.GetFloat("floatKey");

    //获取key为"strKey"的字符串数据
    string strVal = PlayerPrefs.GetString("strKey");
3.删除数据与查数据:
    //删除所有存储数据
    PlayerPrefs.DeleteAll();

    //删除key为"score"的数据
    PlayerPrefs.DeleteKey("score");

    //查找是否存在key为"score"的数据
    bool exist = PlayerPrefs.HasKey("score")

    注意事项：
    数据以键值对的形式存储，可以看做一个字典。
    数据通过键名来读取，当值不存在时，返回默认值。
4.PlayerPrefs数据存在哪里？
    在Mac OS X平台下，存储在~/Library/Preferences文件夹，名为unity.[company name].[product name].plist。
    在Windows平台下，存储在注册表的 HKEY_CURRENT_USER\Software[company name] [product name] 键下*/

public class PlayerPrefsMemory : IDataMemory
{
    //泛型与获取方法的映射
    private Dictionary<Type, Func<string, object>> _dataGatter = new Dictionary<Type, Func<string, object>>
    {
        {typeof(int),(key)=>PlayerPrefs.GetInt(key,0) },
        {typeof(string),(key)=>PlayerPrefs.GetString(key,"") },
        {typeof(float),(key)=>PlayerPrefs.GetFloat(key,0) },

    };
    //泛型与存储方法的映射
    private Dictionary<Type, Action<string, object>> _dataSatter = new Dictionary<Type, Action<string, object>>
    {
        {typeof(int),(key,value)=>PlayerPrefs.SetInt(key,(int)value) },
        {typeof(string),(key,value)=>PlayerPrefs.SetString(key,(string)value) },
        {typeof(float),(key,value)=>PlayerPrefs.SetFloat(key,(float)value) },

    };
    //数据获取
    public T Get<T>(string key)
    {
        Type type = typeof(T);
        var converter = TypeDescriptor.GetConverter(type);

        if(_dataGatter.ContainsKey(type))
        {
            return (T)converter.ConvertTo(_dataGatter[type](key), type);
        }
        else
        {
            Debug.LogError("当前数据存储类型中无此类型。类型名为："+ typeof(T).Name);
            return default(T);//返回默认值
           
        }


    }

    //存储获取
    public void Set<T>(string key, T value)
    {
        Type type = typeof(T);
        if (_dataSatter.ContainsKey(type))
        { 
            _dataSatter[type](key, value);
        }
        else
        {
            Debug.LogError("当前存储中无此数据，数据为key：" + key + "value:" + value);
        }
    }

    public void Clear(string key)
    {

        PlayerPrefs.DeleteKey(key);
    }

    public void ClearAll()
    {

        PlayerPrefs.DeleteAll();
    }

    
}
