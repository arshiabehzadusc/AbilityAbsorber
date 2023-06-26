using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    private float health;
    public float maxLives = 3f;
    // Start is called before the first frame update
    void Start()
    {
        health = maxLives;
        healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            healthLabel.text = "Health: " + health;
        }
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
