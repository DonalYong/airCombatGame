﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderMgr : NormalSingleton<ReaderMgr>
{
    private Dictionary<string, IReader> _readersDic = new Dictionary<string, IReader>();
    public IReader GetReader(string path)
    {
        IReader reader = null;
        if (_readersDic.ContainsKey(path))
        {
            reader =_readersDic[path];
        }
        else
        {
            //从当前的配置中，获取一个新的reader
            //读取当前路径配置的数据，赋值给reader
            reader = ReaderConfig.GetReader(path);
            LoadMgr.Single.Loadconfig(path, (data) => reader.SetData(data));
            if (reader!=null)
            {
                _readersDic[path] = reader;

            }
            else
            {
                Debug.LogError("没有对应的reader，路径：" + path);
            }
           
        }
        return reader;
    }
}
