
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour 
{
    private SpriteRenderer renderer;
    private Gate gate;

    void Start() 
    {
        renderer = GetComponent<SpriteRenderer>();
        gate = GameObject.FindWithTag("Gate").GetComponent<Gate>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ElectricAbility"))
        {
            print("here");
            Color color = HexToColor("E5C1C1");
            renderer.color = color;  // Change here
            gate.openGate();
        }
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}