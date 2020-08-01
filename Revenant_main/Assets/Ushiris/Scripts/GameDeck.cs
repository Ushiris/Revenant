using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Deck))]
public class GameDeck : MonoBehaviour
{
    [SerializeField] Deck deckData;
    [SerializeField] Transform deckPos;
    List<Card> deck;

    void InitDeck()
    {
        deckData.list.ForEach((item) =>
        {
            for (int i = 0; i < item.amount; i++)
            {
                var obj = Instantiate(Resources.Load("Card")) as GameObject;
                obj.transform.SetParent(deckPos);
                obj.transform.localPosition = new Vector3(0, 0.001f + 0.001f * deck.Count, 0);

                var card = obj.GetComponent<Card>();
                deck.Add(card);
                card.iDtype = item.type;
                card.number = item.id;
            }
        });
    }
}
