using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UEventCard : UnityEvent<Card> { }

public class Card : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    public enum IDType:int
    {
        Normal,PR,SP
    }

    public static UEventCard OnCardClick;
    
    public static Dictionary<IDType, string> IDName = new Dictionary<IDType, string>
    {
        { IDType.Normal,"No" },{ IDType.PR,"PR" },{ IDType.SP,"SP" }
    };
    
    Vector3 screenPoint;
    Vector3 offset;

    public IDType iDtype = IDType.Normal;
    public uint number = 0;
    public CardMainData cardData;

    private void Start()
    {
        cardData = CardDataBase.GetCardData(iDtype, number);
        var text = GetComponentInChildren<TMPro.TextMeshPro>();
        text.text = IDName[iDtype] + "." + number;
        if (OnCardClick == null) OnCardClick = new UEventCard();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        float y = transform.position.y;
        transform.position = new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, y, eventData.pointerCurrentRaycast.worldPosition.z);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDown()
    {
        OnCardClick.Invoke(this);
    }
}
