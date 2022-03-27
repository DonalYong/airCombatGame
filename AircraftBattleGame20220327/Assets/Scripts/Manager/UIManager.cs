using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class UIManager : NormalSingleton<UIManager>
{
    private Stack<string> _uiStack = new Stack<string>();
    private Dictionary<string, IView> _views = new Dictionary<string, IView>();//路径和对象的映射
    private Canvas _canvas;
    public Canvas Canvas//得到场景中canvas
    {
        get
        {
            if (_canvas == null)
                _canvas = Object.FindObjectOfType<Canvas>();
            if (_canvas == null)
                Debug.LogError("场景中没有canvas");

            return _canvas;
        }
    }

    //管理UI显示方法
    public IView Show(string path)
    {
        if (_uiStack.Count>0)
        {
            string name = _uiStack.Peek();//peek()方法提取出栈顶发元素但不移除它
            _views[name].Hide();
        }
        IView view = InitView(path);//当前显示的UI初始化
        view.Show();

        _uiStack.Push(path);//当前显示界面压入栈顶
        _views[path] = view;

        return view;
    }

    //UI初始化
    private IView InitView(string path)
    {
        if (_views.ContainsKey(path))//是否是当前已经生成的页面
        {
            return _views[path];
        }
        else
        {
            GameObject viewGO = LoadMgr.Single.LoadPrefab(path, Canvas.transform);//获取到当前的预制体
            //添加脚本
            Type type = Bindutil.GetType(path);
            var component = viewGO.AddComponent(type);
            IView view = null;
            if (component is IView)
            {
                view = component as IView;
                view.Init();
            }
            else
            {
                Debug.LogError("当前添加脚本没有继承自ViewBase");
            }

            return view;

        }
    }

    //ui界面返回方法
    public void Baack()
    {
        if (_uiStack.Count <= 1)
            return;
        string name = _uiStack.Pop();//移除栈顶元素并且返回值就是这个元素
        _views[name].Hide();

        name = _uiStack.Peek();
        _views[name].Show();
    }
}
