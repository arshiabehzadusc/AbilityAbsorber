using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluePuddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion") || other.gameObject.CompareTag("FireAbility")) {
            print("glue removed by fire/explosion");
            Destroy(this.gameObject);
        }
        
    }
}
