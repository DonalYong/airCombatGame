using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendUtil  
{
   public static  RectTransform Rect (this Transform trans)
    {
        return trans.GetComponent<RectTransform>();
    }
}
