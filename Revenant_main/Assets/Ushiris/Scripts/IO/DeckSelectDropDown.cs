using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class DeckSelectDropDown : MonoBehaviour
{
    Dropdown ui;

    private void Awake()
    {
        ui = GetComponent<Dropdown>();
    }

    private void Start()
    {
        Set();
        DeckDataIO.OnSaved.AddListener(Set);
    }
    
    void Set()
    {
        ui.options = new List<Dropdown.OptionData>();
        ui.AddOptions(DeckDataIO.DeckNames);
    }
}
