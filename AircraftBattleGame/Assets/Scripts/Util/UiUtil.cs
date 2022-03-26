using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiUtil : MonoBehaviour
{
   public void Init()
    {

    }
}
public class UiutilData
{
    private Sprite sprite;

    public GameObject Go { get; private set; }
    public RectTransform RectTrans { get; private set; }
    public Button Btn { get; private set; }
    public Image Img { get; private set; }
    public Text Text { get; private set; }

    public UiutilData(RectTransform rectTrans)
    {
        RectTrans = rectTrans;
        Go = rectTrans.gameObject;
        Btn = rectTrans.GetComponent<Button>();
        Img = RectTrans.GetComponent<Image>();
        Text = rectTrans.GetComponent<Text>();
    }
    //Button点击事件监听
    public void AddListener(Action action)
    {
        if (Btn !=null)
        {
            Btn.onClick.AddListener(() => action());

        }
        else
        {
            Debug.LogError("当前物体上没有button组件，物体名称为：" + Go.name);

        }
    }
    //Img组件设置
    public void SetSprite(Sprite sprite)
    {
        if (Img!=null)
        {
            Img.sprite = sprite;

        }
        else
        {
            Debug.LogError("当前物体上没有image组件，物体名称为："+Go.name);
        }
    }
}
