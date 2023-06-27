using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_script : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero; 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        rb.constraints &= ~RigidbodyConstraints2D.FreezeAll;
    }
}