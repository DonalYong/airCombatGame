using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMgr : NormalSingleton<LoadMgr>,ILoader
{
    private ILoader _loader;
    public LoadMgr()
    {
        _loader = new ResourceLoader();
    }
    public GameObject LoadPrefab(string path, Transform parent = null)
    {
        //通过类型名挂载脚本
        //GameObject temp = _loader.LoadPrefab(path, parent);
        //Type type = Type.GetType(temp.name.Remove(temp.name.Length - 7));//获取type类型，并去掉后七位“（clone）”

        //Type type = Bindutil.GetType(path);
        //temp.AddComponent(type);
        //return temp;
        return _loader.LoadPrefab(path, parent);
    }

    public void Loadconfig(string path, Action<object> complete)
    {
        _loader.Loadconfig(path, complete);
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        return _loader.Load<T>(path);
    }

    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        return _loader.LoadAll<T>(path);
    }
}
