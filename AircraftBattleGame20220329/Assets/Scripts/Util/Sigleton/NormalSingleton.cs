 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSingleton<T> where T: class,new()
{
    private static T _Single;
    public static T Single
    {
        get
        {
            if (_Single==null)
            {
                T t = new T();
                if (t is MonoBehaviour)
                {
                    Debug.LogError("Mono类请使用Monosinngleton");
                    return null;
                }
                _Single = t;
            }
            return _Single;
        }
    }
}
