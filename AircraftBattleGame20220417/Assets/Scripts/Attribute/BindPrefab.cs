using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//绑定脚本和预制体
[AttributeUsage(AttributeTargets.Class)]
public class BindPrefab : Attribute{
    public string Path { get; private set; }
    public BindPrefab(string path)
    {
        Path = path;
    }
}
