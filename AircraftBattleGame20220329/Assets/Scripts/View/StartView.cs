using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BindPrefab(Paths.START_VIEW)]//类和预制体绑定
public class StartView : ViewBase
{
    public override void Init()
    {
        Util.Get("Start").AddListener(() =>
        {
            Debug.Log("我是开始按钮");
            UIManager.Single.Show(Paths.SELECTED_HERO_VIEW);
            
        });
    }
}
