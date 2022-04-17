﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderConfig : MonoBehaviour
{
    private static readonly Dictionary<string, Func<IReader>> readersDic = new Dictionary<string, Func<IReader>>()
    {
        {".json",()=>new JsonReader() }
    };

    public static object Single { get; internal set; }

    public static IReader GetReader(string path)
    {
        foreach (KeyValuePair<string,Func<IReader>> pair  in readersDic)
        {
            if (path.Contains(pair.Key))
            {
                return pair.Value();
            }
        }
        Debug.LogError("没有找到对应文件的读取器，文件路径：" + path);
        return null;
    }
}
