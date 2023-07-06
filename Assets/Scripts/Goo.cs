using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided with goo");
        // Check if the collided object has a Rigidbody2D (which it should if it's moving)
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        
        if (rb != null) // if the collided object has a Rigidbody2D
        {
            // Stop the object by nullifying its velocity
            rb.velocity = Vector2.zero;
            
            // Also stop any rotational movement
            rb.angularVelocity = 0f;
        }
    }

}
