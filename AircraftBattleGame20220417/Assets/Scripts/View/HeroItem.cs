using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//英雄选择动画执行部分
public class HeroItem : MonoBehaviour
{
    private Color _default = Color.gray;
    private Color _selected = Color.white;
    private float _time = 0.8f;
    private Image _image;
    private Action _callBack;
    void Start()
    {
        _image = transform.GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(Selected);
    }

    // Update is called once per frame
    private void Selected()
    {
        //先恢复默认状态
        if (_callBack != null)
            _callBack();

        _image.DOKill();
        _image.DOColor(_selected, _time);
    }
    public void Unselected()
    {
        _image.DOKill();
        _image.DOColor(_default, _time);

    }
    
    public void AddResetListener(Action action)
    {
        _callBack = action;
    }
}
