using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedHero : ViewBase
{
    private HeroItem[] _items;

    // Start is called before the first frame update
    void Start()
    {
        //为hero下每一个子对象挂载脚本.03

        _items = new HeroItem[transform.childCount];
        HeroItem item = null;
        foreach (Transform trans in transform)
        {
            item = trans.gameObject.AddComponent<HeroItem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
