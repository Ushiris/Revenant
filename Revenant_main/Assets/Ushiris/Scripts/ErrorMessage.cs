using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    static Text lines;

    private void Awake()
    {
        lines = GameObject.Find("ErrorMessage").GetComponent<Text>();
    }

    public static void InputStringError(GameObject source)
    {
        Debug.Log("String error!:" + source.name);
        lines.text += "\n入力が不正です。";
        StopWatch.Summon(5, ()=> { TimeOutErrorMessage(); }, lines.gameObject);
    }

    public static void TimeOutErrorMessage()
    {
        lines.text.Remove(0);
        var end = lines.text.IndexOf("\n");
        lines.text.Remove(0, end + 1);
    }
}
