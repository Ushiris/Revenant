using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public static GameObject Generate(Card.IDType id_type, uint number)
    {
        var card = Instantiate(Resources.Load("Card")) as GameObject;
        var data = card.GetComponent<Card>();

        data.iDtype = id_type;
        data.number = number;

        return card;
    }
}
