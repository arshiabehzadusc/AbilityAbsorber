using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningHazard : MonoBehaviour
{
    public float rotationSpeed;
    private bool stuck = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (stuck == false) {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotationAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // EVERY ENEMY/OBJECT NEAR GLUE SHOULD HAVE THIS GLUE
        if (collision.gameObject.CompareTag("Glue")) {
            Debug.Log("SpinningHazard stuck in glue");
            stuck = true;
        }
    }
}
