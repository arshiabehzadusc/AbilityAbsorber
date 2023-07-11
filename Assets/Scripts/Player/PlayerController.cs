using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    public float health;
    public float batHealth;
    public float maxLives = 3f;
    public SendToGoogle sendtogoogle;
    public MessageToPlayer messageToPlayer;
    public bool isBat;
    private GameObject enemy;
    private Level2_Rock rockEnemy;
    public PauseMenuController pmc;

    public PlayerMovement playerMov;
    // Start is called before the first frame update
    void Start()
    {
        isBat = false;
        batHealth = 2;
        health = maxLives;
        healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
        sendtogoogle = GetComponent<SendToGoogle>();
        enemy = GameObject.FindGameObjectWithTag("RockEnemy");
        rockEnemy = enemy.GetComponent<Level2_Rock>();
    }

    public float getHealthy()
    {
        return health;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RockEnemy") && rockEnemy.getIsCorpse() == false)
        {
            TakeDamage(1f, "rock");
        }
        else if (collision.gameObject.CompareTag("SpinningHazard")) {
            TakeDamage(3f, "SpinningHazard");
        }
    }

    void Update()
    {

    }

    public void TakeDamage(float damage, string enemy)
    {
        if (isBat)
        {
            if (batHealth > 0)
            {
                batHealth -= damage;
                pmc.isDead = true;
                healthLabel.text = "Health: " + health;
                Debug.Log("Bat Health" + batHealth);
            }
            if (batHealth <= 0)
            {
                messageToPlayer.DisplayDied();
                Vector2 playerposition = transform.position;
                sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (health > 0)
            {
                health -= damage;
                healthLabel.text = "Health: " + health;
            }
            if (health <= 0)
            {
                messageToPlayer.DisplayDied();
                pmc.isDead = true;
                Vector2 playerposition = transform.position;
                sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
                gameObject.SetActive(false);
            }
        }
    }
}
