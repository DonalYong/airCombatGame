using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BindPrefab(Paths.SELECTED_HERO_VIEW)]
public class SelectedHeroView :ViewBase
{
    
    protected override void InitChild()
    {
        Util.Get("Heros").Go.AddComponent<SelectedHero>();//挂载脚本到SelectedHero
        Util.Get("OK/Start").AddListener(() =>
        {
            //todo:切换到选择关卡界面
        });
        Util.Get("Exit").AddListener(() =>
        {
            Application.Quit();
        });
        Util.Get("Strengthen").AddListener(() =>
        {
            //切换强化界面
            UIManager.Single.Show(Paths.STRENGTHEN_VIEW);
        });
    }
}
