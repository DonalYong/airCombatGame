using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//协程管理器
public class CoroutineMgr : MonoSingleton<CoroutineMgr>
{
    private Dictionary<int, CoroutineController> _controllersDic;//通过id获取controller对象
   
    public CoroutineMgr()
    {
        _controllersDic = new Dictionary<int, CoroutineController>();
    }
    //执行当前传入的迭代器
    public int Execute(IEnumerator routine,bool autoStart =true)
    {
        CoroutineController controller = new CoroutineController(this, routine);
        _controllersDic.Add(controller.ID, controller);//将控制器的Id加入到字典中；

        if (autoStart)
            StartExecute(controller.ID);

         return controller.ID;
    }
    //只执行一次
    public void ExecuteOnce(IEnumerator routine)
    {
        CoroutineController controller = new CoroutineController(this, routine);
        controller.Start();
    }
    //重新开始
    public void Restart(int id)
    {
        var controller = GetController(id);
        if (controller != null)
            controller.ReStart();
    }
    //开始执行
    public void StartExecute(int id)
    {
        var controller = GetController(id);
        if (controller !=null)
            controller.Start();

    }
    //暂停
    public void Pause(int id)
    {
        var controller = GetController(id);
        if (controller != null)
            controller.Pause();
    }
    //停止
    public void Stop(int id)
    {
        var controller = GetController(id);
        if (controller != null)
            controller.Stop();
    }
    //继续
    public void Continue(int id)
    {
        var controller = GetController(id);
        if (controller != null)
            controller.Continue();
    }
    //拿到控制器的id
    private CoroutineController GetController(int id)
    {
        if (_controllersDic.ContainsKey(id))
        {
            return _controllersDic[id];
        }
        else
        {
            Debug.LogError("当前id存在:" + id);
            return null;
        }
    }
        
}
