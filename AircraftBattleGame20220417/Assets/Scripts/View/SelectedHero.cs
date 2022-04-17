using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedHero :MonoBehaviour
{
    private HeroItem[] _items;

    // Start is called before the first frame update
    void Start()
    {
        //为hero下每一个子对象挂载脚本.03

        _items = new HeroItem[transform.childCount];
        HeroItem item = null;
        int index = 0;
        foreach (Transform trans in transform)
        {
            item = trans.gameObject.AddComponent<HeroItem>();
            item.AddResetListener(ResetState);//回调
            _items[index] = item;
            index++;
        }
    }
    private void ResetState()
    {
        foreach (HeroItem item in _items)
        {
            item.Unselected();
        }
    }
    
}
