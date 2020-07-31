using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddDeckUI : MonoBehaviour
{
    public Card.IDType type = Card.IDType.Normal;
    public int number = 0;
    public int amount = 0;

    [SerializeField] Deck deck;

    public void PushDeck()
    {
        deck.Add(new DeckElement { amount = (uint)amount, id = (uint)number, type = type });
    }

    public void SetType(int idx)
    {
        type = (Card.IDType)idx;
    }

    public void SetNum(string num)
    {
        try { number = int.Parse(num); } catch { number = 0; }
    }

    public void SetAmount(string num)
    {
        try { amount = int.Parse(num); } catch { amount = 0; }
    }
}