using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer renderer;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // touching the actual magnet
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("ElectricAbility"))
        {
            print("here");
            Color color = HexToColor("FFFFFF");
            renderer.material.color = color;
        }
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}
