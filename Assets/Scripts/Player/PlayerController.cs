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
    private NewGhostEnemy ghostEnemy;
    public PauseMenuController pmc;

    public PlayerMovement playerMov;
    private AbilityManager abilityManager;
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
         ghostEnemy = GameObject.FindGameObjectWithTag("GhostEnemy").GetComponent<NewGhostEnemy>();
        abilityManager = GetComponent<AbilityManager>();

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
        else if (collision.gameObject.CompareTag("GhostEnemy") && ghostEnemy.getIsCorpse() == false)
        {   Debug.Log("Ghost dealth damage to player");
            TakeDamage(1f, "ghost");
        }
        else if (collision.gameObject.CompareTag("SpinningHazard")) {
            TakeDamage(3f, "SpinningHazard");
        }
        else if (collision.gameObject.CompareTag("MagnetEnemy")) {
            if (abilityManager.getSelectedAbility() == "electric") {
                TakeDamage(3f, "MagnetEnemy");
            }
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
