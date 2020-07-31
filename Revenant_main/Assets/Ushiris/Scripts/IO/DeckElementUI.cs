using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DeckElementUI : MonoBehaviour
{
    [SerializeField] Text info;
    [SerializeField] Button enter;

    public void SetInfoText(string text)
    {
        info.text = text;
    }

    public void SetRemoveFunc(UnityAction func)
    {
        enter.onClick.AddListener(func);
    }

    public void SetPos(int index)
    {
        var rect = gameObject.GetComponent<RectTransform>();
        var x = index < 27 ? rect.rect.position.x : rect.rect.position.x + rect.rect.width + 10;
        var y = index < 27 ? 0 - index * rect.rect.height : 0 - (index - 27) * rect.rect.height;
        rect.localPosition = new Vector2(x, y);
    }
}
