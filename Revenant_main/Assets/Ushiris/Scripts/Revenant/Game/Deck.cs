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
    public string DeckName { get; set; }

    public List<DeckElement> List { get; private set; }
    public OnAddDeck onAddDeck = new OnAddDeck();
    public int ListLength { get { return List.Count; } }

    private void Awake()
    {
        List = new List<DeckElement>();
    }

    public void Add(DeckElement data)
    {
        List.Add(data);
        onAddDeck.Invoke(data);
    }

    public void Remove(DeckElement data)
    {
        List.Remove(data);
    }

    public void SetDeck(List<DeckElement> data)
    {
        List = data;
    }
}