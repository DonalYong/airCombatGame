using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bindutil{
    private static Dictionary<string,Type> _prefabAandScriptMap = new Dictionary<string,Type>();
    //绑定路径和type类型的映射
    public static void Bind(string path, Type type) {
        if (!_prefabAandScriptMap.ContainsKey(path))
        {
            _prefabAandScriptMap.Add(path, type);
        }
        else
        {
            Debug.LogError("当前数据中已经存在路径：" + path);
        }

    }
    //获取当前的type
    public static Type GetType(string path)
    {
        if (_prefabAandScriptMap.ContainsKey(path))
        {
            return _prefabAandScriptMap[path];

        }
        else
        {
            Debug.LogError("当前数据中没有包含路径：" + path);
            return null;
        }
    }
}
