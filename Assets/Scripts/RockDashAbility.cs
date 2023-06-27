using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDashAbility : MonoBehaviour
{
    public float dashSpeed;
    public float startDashTime;
    private float dashTime;
    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        if(dashTime <= 0)
        {
            // Find the direction to the player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            direction = (player.transform.position - transform.position).normalized;
            dashTime = startDashTime;
        }
        else
        {
            dashTime -= Time.deltaTime;
            rb.velocity = direction * dashSpeed;
        }
    }
}
