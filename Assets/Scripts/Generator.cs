// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Generator : MonoBehaviour
// {
//     // Start is called before the first frame update

//     private SpriteRenderer renderer;

//     void Start()
//     {
//         renderer = GetComponent<SpriteRenderer>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     // touching the actual magnet
//     private void OnTriggerEnter2D(Collider2D other) 
//     {
//         if (other.gameObject.CompareTag("ElectricAbility"))
//         {
//             print("here");
//             Color color = HexToColor("E5C1C1");
//             renderer.material.color = color;
//         }
//     }

//     private Color HexToColor(string hex)
//     {
//         Color color = Color.black;
//         ColorUtility.TryParseHtmlString("#" + hex, out color);
//         return color;
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour 
{
    private SpriteRenderer renderer;

    void Start() 
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ElectricAbility"))
        {
            print("here");
            Color color = HexToColor("E5C1C1");
            renderer.color = color;  // Change here
        }
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}