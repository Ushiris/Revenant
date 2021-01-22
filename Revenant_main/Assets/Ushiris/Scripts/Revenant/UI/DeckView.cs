using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckView: MonoBehaviour
{
    [SerializeField] Deck deck;
    List<DeckElementUI> list;

    private void Awake()
    {
        list = new List<DeckElementUI>();
    }

    private void Start()
    {
        deck.onAddDeck.AddListener(AddElement);
        DeckDataIO.OnLoad.AddListener(OnDeckLoad);
    }

    public void AddElement(DeckElement data)
    {
        var obj = Instantiate(Resources.Load("DeckEditElement")) as GameObject;
        obj.GetComponent<RectTransform>().SetParent(gameObject.transform);
        obj.GetComponent<RectTransform>().localPosition = Vector3.zero;

        var element = obj.GetComponent<DeckElementUI>();
        list.Add(element);
        element.SetPos(list.Count - 1);

        var str = data.amount + ":" + CardDataBase.GetCardData(data.type, data.id).Name;
        element.SetInfoText(str);
        element.SetRemoveFunc(() => 
        {
            deck.Remove(data);
            list.Remove(element);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetPos(i);
            }
            Destroy(obj);
        });
    }

    public void OnDeckLoad()
    {
        list.ForEach((item) =>
        {
            Destroy(item.gameObject);
        });
        list.Clear();

        deck.List.ForEach((item) =>
        {
            AddElement(item);
        });
    }
}
