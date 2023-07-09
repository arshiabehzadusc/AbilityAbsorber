using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public GameObject flame; // Reference to Flame GameObject
    public PlayerController playerController; // Reference to PlayerController script

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the colliding object is the player
        // Make sure the player gameobject has the tag "Player" in Unity inspector
        if(other.gameObject.tag == "Player")
        { 
            // If the flame is active
            if(flame.activeInHierarchy)
            {
                // Call TakeDamage function from PlayerController script
                playerController.TakeDamage(0.01f,"river");
                Debug.Log("river dealt damage to player in fire form");
            }
        }
    }
}
