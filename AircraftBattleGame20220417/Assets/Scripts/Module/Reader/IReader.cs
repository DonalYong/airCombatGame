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

    ICollection<string> keys();//遍历键值接口根本上是通过遍历字典键值实现
}
