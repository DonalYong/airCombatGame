using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABLoader : ILoader
{
    public T[] LoadAll<T>(string path) where T : UnityEngine.Object
    {
        throw new NotImplementedException();
    }

    public void Loadconfig(string path, Action<object> complete)
    {
        throw new NotImplementedException();
    }

    public GameObject LoadPrefab(string path, Transform parent = null)
    {
        throw new System.NotImplementedException();
    }

    public T Load<T>(string path) where T : UnityEngine.Object
    {
        throw new NotImplementedException();
    }
}
