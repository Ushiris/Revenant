using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneControl
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void OnEditorStart()
    {
        SceneManager.LoadScene("Init", LoadSceneMode.Additive);
        DebugLogger.Log("Load:InitScene");
    }
}
