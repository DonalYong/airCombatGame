using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyItem : MonoBehaviour,IviewUpdate
{
    public enum ItemKey
    {
        name,
        value,
        cost,
        grouth,
        COUNT
    }
    private static int _itemId=-1;//自增id,计算当前位置
       private string _key;
  
    
   public void Init(string key)
    {
        _key = key;
        _itemId++;
        UpdatePos(_itemId);
    }
    //更新item位置
    private void UpdatePos(int itemId)
    {
        RectTransform rect = transform.Rect();
        float offset = rect.rect.height * itemId;
        rect.anchoredPosition -= offset * Vector2.up;

    }
    //更新id，通过飞机id拿到配置
    private void UpdatePlaneId(int planeId)
    {
        
        UpdateData(planeId);
    }
    private void UpdateData(int planeId)
    {
        for (ItemKey i = 0; i < ItemKey.grouth; i++)
        {
            Transform trans = transform.Find(ConvertName(i));
            if (trans !=null)
            {
                string key = KeysUtil.GetPropertyKeys(planeId, _key + i);//id+name
                trans.GetComponent<Text>().text = DataMgr.Single.GetString(key);
            }
            else
            {
                Debug.LogError("当前预制体名称错误，正确名称：" + ConvertName(i));
            }
        }
    }
    private string ConvertName(ItemKey key)
    {
        string first = key.ToString().Substring(0, 1).ToUpper();
        string others = key.ToString().Substring(1);
        return first + others;
    }

    public void ViewUpdate()
    {
        UpdatePlaneId(GameStateModel.Single.SelectedPlaneId);
    }
}
