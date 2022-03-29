using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader {

   GameObject LoadPrefab(string path, Transform parent = null);
    //加载配置
    void Loadconfig(string path, Action<object> complete);
}
