using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour,IDragHandler,IBeginDragHandler
{
    public enum IDType
    {
        Normal,PR,SP
    }

    public static Dictionary<IDType, string> IDName = new Dictionary<IDType, string>
    {
        { IDType.Normal,"No" },{ IDType.PR,"PR" },{ IDType.SP,"SP" }
    };
    
    private Vector3 screenPoint;
    private Vector3 offset;

    public IDType IDtype;
    public uint Number;

    private void Start()
    {
        var text = GetComponentInChildren<TMPro.TextMeshPro>();
        text.text = IDName[IDtype] + "." + Number;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
}
