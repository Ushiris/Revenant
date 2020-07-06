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

    Card.IDType id_t;
    uint id;

    private void Start()
    {
        id_t = Card.IDType.Normal;
        id = 0;
    }

    public GameObject GenerateEnter()
    {
        var card = Instantiate(Resources.Load("Card")) as GameObject;
        var data = card.GetComponent<Card>();

        data.IDtype = id_t;
        data.Number = id;

        return card;
    }

    public void SetIDType(Card.IDType type)
    {
        id_t = type;
    }

    public void SetID(string ID)
    {
        try
        {
            id = uint.Parse(ID);
        }
        catch
        {

        }
    }
}
