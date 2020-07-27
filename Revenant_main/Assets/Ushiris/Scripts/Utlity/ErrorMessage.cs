using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : SingletonMonoBehaviour<ErrorMessage>
{
    Text lines;

    private void Start()
    {
        lines = GetComponent<Text>();
    }

    public void InputStringError(GameObject source)
    {
        DebugLogger.Log("String error!:" + source.name);
        lines.text += "\n入力が不正です。";
        StopWatch.SummonOneShot(5, TimeOutErrorMessage, lines.gameObject);
    }

    public void TimeOutErrorMessage()
    {
        lines.text.Remove(0,1);
        var end = lines.text.IndexOf("\n");
        lines.text.Remove(0, end + 1);
    }
}
