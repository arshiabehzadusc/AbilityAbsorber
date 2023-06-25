using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of player movement.
    private Rigidbody2D rb;  // Reference to Rigidbody2D component.

    // Use this for initialization
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called once per frame, but with a fixed time increment
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal Input
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical Input

        // Create a Vector2 movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Apply movement to the Rigidbody2D
        rb.velocity = movement * speed;
    }
}
