using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class GameDeck : MonoBehaviour
{
    [SerializeField] Deck deckData;
    [SerializeField] Transform deckPos;
    List<Card> deck;

    public void InitDeck()
    {
        deckData.List.ForEach((item) =>
        {
            for (int i = 0; i < item.amount; i++)
            {
                var obj = Card.Generate(item.type, item.id);
                obj.transform.SetParent(deckPos);
                obj.transform.localPosition = new Vector3(0, 0.001f + 0.001f * deck.Count, 0);

                var card = obj.GetComponent<Card>();
                deck.Add(card);
            }
        });

        Shuffle();
    }

    public void Shuffle()
    {
        deck = deck.OrderBy(a => System.Guid.NewGuid()).ToList();
    }
}
