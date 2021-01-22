using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerate_T : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Card.Generate(Card.IDType.Normal, (uint)Mathf.FloorToInt(Random.Range(1, 2000)));
        }
    }
}
