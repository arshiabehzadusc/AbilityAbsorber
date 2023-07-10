using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGhostEnemy: MonoBehaviour
{

    
    private int currentHealth;
    
    private float health;
    public float maxLives = 3f;
    public Renderer renderer;
    public bool is_corpse = false; 
    private RockDashAbility dashAbility;    
    private Rigidbody2D rb;
    private PlayerController playerController; //to deal damage to player

    

    void Start()
    {
        health = maxLives;
        dashAbility = GetComponent<RockDashAbility>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.CompareTag("Player"))
        {   Debug.Log("Ghost dealth damage to player");
            playerController.TakeDamage(1.0f,"ghost");
        }
       
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            print(health);
        }
        if (health <=0)
        {
            // Destroy object - gameObject.SetActive(false);

            // make into corpse
            Debug.Log("killed ghost");
            Color color = HexToColor("372E2E");
            renderer.material.color = color;
            is_corpse=true;
            if(is_corpse==true)
            {
                // Set the velocity to zero
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
                // Make the Rigidbody2D kinematic, so it's no longer affected by forces
                rb.isKinematic = true;
            }
        }
    }

        

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }

    public bool get_is_corpse() {
        return is_corpse;
    }

}
