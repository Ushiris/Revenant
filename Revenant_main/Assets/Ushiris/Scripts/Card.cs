using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum IDType
    {
        Normal,PR,SP
    }

    Dictionary<IDType, string> IDName = new Dictionary<IDType, string>
    {
        { IDType.Normal,"No." },{ IDType.PR,"PR." },{ IDType.SP,"SP." }
    };

    public IDType IDtype;
    public uint Number;

    private void Start()
    {
        var text = GetComponentInChildren<TMPro.TextMeshPro>();
        text.text = IDName[IDtype] + Number;
    }
}
