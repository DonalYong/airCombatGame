using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//子物体查找工具
public class UiUtil : MonoBehaviour
{
    //要查找物体的名字与数据类的映射
    private Dictionary<string, UiutilData> _datas;

   public void Init()
    {
        _datas = new Dictionary<string, UiutilData>();
        //初始化时遍历这个物体下的所有子物体
        RectTransform rect = transform.GetComponent<RectTransform>();//获取到当前物体
        foreach (RectTransform rectTransform in rect)
        {
            _datas.Add(rectTransform.name,new UiutilData (rectTransform));
        }
    }
    //获取子物体或身上的组件
    public UiutilData Get(string name)
    {
        if (_datas.ContainsKey(name))
        {
            //Debug.Log("得到子物体");
            return _datas[name];

        }
        else//如果没有，按路径通过transform查找
        {
            Transform temp = transform.Find(name);
            if (temp == null)
            {
                Debug.LogError("无法按照路径查找到物体，路径为：" + name);
                return null;
            }
            else
            {
                //Debug.Log("得到孙子物体或子物体组件");
                _datas.Add(name, new UiutilData(temp.GetComponent<RectTransform>()));
                return _datas[name];
                
            }
        }
    }
}
//定义各UI组件数据类型
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
