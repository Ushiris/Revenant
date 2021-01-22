using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UEventCard : UnityEvent<Card> { }

public class Card : MonoBehaviour,IDragHandler
{
    public enum IDType:int
    {
        Normal,PR,SP
    }

    public static UEventCard OnCardClick = new UEventCard();
    
    public static Dictionary<IDType, string> IDName = new Dictionary<IDType, string>
    {
        { IDType.Normal,"No" },{ IDType.PR,"PR" },{ IDType.SP,"SP" }
    };

    public static GameObject Generate(IDType id_type, uint number)
    {
        var card = Instantiate(ResourceSettings.Load<GameObject>(ResourceSettings.Instance().card)) as GameObject;
        var data = card.GetComponent<Card>();

        data.iDtype = id_type;
        data.number = number;

        return card;
    }

    public IDType iDtype = IDType.Normal;
    public uint number = 0;
    public CardMainData DefaultCardData;
    TMPro.TextMeshPro IDtext;

    private void Start()
    {
        DefaultCardData = CardDataBase.GetCardData(iDtype, number);
        IDtext = GetComponentInChildren<TMPro.TextMeshPro>();
        IDtext.text = IDName[iDtype] + "." + number;
    }

    void Hide()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        float y = transform.position.y;
        transform.position = new Vector3(eventData.pointerCurrentRaycast.worldPosition.x, y, eventData.pointerCurrentRaycast.worldPosition.z);
    }

    private void OnMouseDown()
    {
        OnCardClick.Invoke(this);
    }
}
