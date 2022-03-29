using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReader 
{
    //Reader ["plans"][0]["planeId"]
    //索引器
   IReader this [string key] { get; }
   IReader this [int key] { get; }
    void Get<T>(Action<T> callBack);//通过异步获取内部值
    void SetData(object data);

}
