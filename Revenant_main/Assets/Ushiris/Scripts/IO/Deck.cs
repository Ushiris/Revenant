using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct DeckElement
{
    public Card.IDType type;
    public uint id;
    public uint amount;
}

public class OnAddDeck : UnityEvent<DeckElement> { }

public class Deck : MonoBehaviour
{
    public string deckName { get; set; }

    public List<DeckElement> list { get; private set; }
    public OnAddDeck onAddDeck = new OnAddDeck();
    public int ListLength { get { return list.Count; } }

    private void Awake()
    {
        list = new List<DeckElement>();
    }

    public void Add(DeckElement data)
    {
        list.Add(data);
        onAddDeck.Invoke(data);
    }

    public void Remove(DeckElement data)
    {
        list.Remove(data);
    }

    public void SetDeck(List<DeckElement> data)
    {
        list = data;
    }
}