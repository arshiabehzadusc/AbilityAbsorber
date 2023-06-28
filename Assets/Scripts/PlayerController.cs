using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    private float health;
    public float maxLives = 3f;

    private RockEnemy rockEnemy;
    // Start is called before the first frame update
    void Start()
    {
        health = maxLives;
        healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rockEnemy = collision.gameObject.GetComponent<RockEnemy>();
        if (collision.gameObject.CompareTag("RockEnemy") && !rockEnemy.is_corpse)
        {
            TakeDamage(1f);
        }
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
