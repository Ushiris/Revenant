using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class CardTypeDropdown : MonoBehaviour
{
    Dropdown dropdown;

    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
        var options = new List<string>(Card.IDName.Values);
        dropdown.AddOptions(options);
    }
}
