using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineItem : MonoBehaviour
{
    //标志协程状态
   public enum CoroutineState
    {
        WAITTING,
        RUNNING,
        PASUED,
        STOP

    }
    public CoroutineState State { get; set; }
    //yield return实际上是依次返回它当前的元素，再次执行它会找到迭代器下一个yield return返回当前的值
    public IEnumerator Body (IEnumerator routine)
    {
        //等待
        while(State == CoroutineState.WAITTING)
        {
            yield return null;//等待执行（yield return null等待一帧）
        }
        //正在执行
        while (State == CoroutineState.RUNNING)
        {
            if (State == CoroutineState.PASUED)
            {
                yield return null;
            }
            else
            {
                if(routine!=null && routine.MoveNext())
                {
                    yield return routine.Current;//返回当前的值
                }
                else
                {
                    State = CoroutineState.STOP;
                }
            }
        }
    }
}
