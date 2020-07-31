using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRequestUI : MonoBehaviour
{
    int index = 0;
    [SerializeField] DeckDataIO deckIO;

    public void Load()
    {
        deckIO.Load(index);
    }

    public void SetIndex(int idx)
    {
        index = idx;
    }
}
