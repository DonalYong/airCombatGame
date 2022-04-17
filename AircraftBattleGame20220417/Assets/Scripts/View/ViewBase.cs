using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class ViewBase : MonoBehaviour, IView
{

    //工具初始化设计，有需求再调用
    private HashSet<ViewBase> _views;//所有子界面缓存
    private UiUtil _util;
    private List<IviewUpdate> _viewUpdates;
  
    protected UiUtil Util
    {
        get
        {
            if (_util == null)
            {
                _util = gameObject.AddComponent<UiUtil>();
                _util.Init();

            }
            return _util;
        }
    }


    public virtual void Init()
    {
        InitChild();//所有子物体生成添加等
        InitSubview();//获取所有的子view
       
        InitAllSubView();//执行所有子类的初始化

        InitSubViewObjects();//获取所有的update对象
        AddUpdateAction();
    }
    protected abstract void InitChild();
    private void InitSubview()
    {
        //找到子物体上所有的viewbase
        _views = new HashSet<ViewBase>();
        ViewBase view = null;
        foreach (Transform trans in transform)
        {
            view = trans.GetComponent<ViewBase>();
            if (view != null)
                _views.Add(view);

        }

    }

    private void InitSubViewObjects()
    {
        _viewUpdates = transform.GetComponentsInChildren<IviewUpdate>().ToList();
        
    }
    //初始化所有的子项View
    private void InitAllSubView()
    {
        foreach (ViewBase view in _views)
        {
            view.Init();
        }
    }
    private void AddUpdateAction()
    {
        //对所有的button事件进行监听
        foreach (Button button  in GetComponentsInChildren<Button>())
        {
            button.onClick.AddListener(UpdateAction);
        }

    }
    //显示
    public virtual void Show()
    {
        gameObject.SetActive(true);
        foreach (ViewBase view in _views)
        {
            view.Show();
        }
    }
    //隐藏
    public virtual void Hide()
    {
        gameObject.SetActive(true);
        foreach (ViewBase view in _views)
        {
            view.Hide();
        }
        gameObject.SetActive(false);
    }

    private void UpdateAction()
    {
        foreach (IviewUpdate update in _viewUpdates)
        {
            update.ViewUpdate();
        }
    }
    public virtual void ViewUpdate()
    {
        
    }
}
