using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOrderUI : MonoBehaviour
{
    public Card.IDType id_t;
    public uint id;

    private void Start()
    {
        SetIDType(0);
        SetID("1");
    }

    public void SetIDType(int value)
    {
        id_t = new List<Card.IDType>(Card.IDName.Keys)[value];
    }

    public void SetID(string ID)
    {
        try
        {
            id = uint.Parse(ID);
        }
        catch
        {
            ErrorMessage.Instance.InputStringError(gameObject);
        }
    }

    public void Generate()
    {
        CardGenerator.Generate(id_t, id);
    }
}
