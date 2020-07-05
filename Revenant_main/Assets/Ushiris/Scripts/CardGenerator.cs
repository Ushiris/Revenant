using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public static GameObject Generate(Card.IDType id_type, uint number)
    {
        var card = Instantiate(Resources.Load("Card")) as GameObject;
        var data = card.GetComponent<Card>();

        data.IDtype = id_type;
        data.Number = number;

        return card;
    }
}
