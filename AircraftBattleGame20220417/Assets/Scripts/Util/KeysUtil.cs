﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysUtil : MonoBehaviour
{
   public static string GetPropertyKeys(int id ,string name )
    {
        return id + name;
    }
}
