﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogger : MonoBehaviour
{
    public static void Log(object message)
    {
        Debug.Log(message);
    }

    public static void Log(object message, Object context)
    {
        Debug.Log(message, context);
    }
}
