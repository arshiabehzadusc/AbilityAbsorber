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
    private RockAbility rockAbility;
    public PlayerMovement playerMov;
    private AbilityManager abilityManager;

    public Dictionary<string, float> healthLevels;
    // Start is called before the first frame update
    void Start()
    {
        isBat = false;
        batHealth = 2;
        health = maxLives;
        ///healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
        sendtogoogle = GetComponent<SendToGoogle>();
        enemy = GameObject.FindGameObjectWithTag("RockEnemy");
        if (enemy != null)
        {
            rockEnemy = enemy.GetComponent<Level2_Rock>();
        }

        if (GameObject.FindGameObjectWithTag("GhostEnemy") != null)
        {
            ghostEnemy = GameObject.FindGameObjectWithTag("GhostEnemy").GetComponent<NewGhostEnemy>();
        }
        rockAbility = GetComponent<RockAbility>();
        abilityManager = GetComponent<AbilityManager>();
        healthLevels = new Dictionary<string, float>();
        healthLevels.Add("none", 7f);
        healthLevels.Add("fire", 10f);
        healthLevels.Add("screech", 2f);
        healthLevels.Add("glue", 7f);
        healthLevels.Add("ram", 7f);
        healthLevels.Add("electric", 7f);
        healthLevels.Add("magnet", 7f);
        healthLevels.Add("stealth", 12f);
    }

    public float getHealthy()
    {
        return health;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RockEnemy") && rockEnemy.getIsCorpse() == false && abilityManager.getSelectedAbility() != "glue")
        {
            TakeDamage(1f, "rock");
        }
        if (collision.gameObject.CompareTag("GhostEnemy") && ghostEnemy.getIsCorpse() == false && rockAbility.isRushing == false )
        {   Debug.Log("Ghost dealt damage to player");
            TakeDamage(1f, "ghost");
        }
        if (collision.gameObject.CompareTag("GhostEnemy")  && ghostEnemy.getIsCorpse() == false && abilityManager.getSelectedAbility() == "ram" && rockAbility.isRushing == true)
        {    
            Debug.Log("Player dealt damage to ghost by ramming");
            ghostEnemy.TakeDamage(1.0f);
        }
        if (collision.gameObject.CompareTag("Diamond")  &&  abilityManager.getSelectedAbility() == "ram" && rockAbility.isRushing == true)
        {    
            Debug.Log("Player took damage by ramming into diamond");
            TakeDamage(0.5f,"Diamond");
        }
        if (collision.gameObject.CompareTag("SpinningHazard")) {
            TakeDamage(3f, "SpinningHazard");
        }
        if (collision.gameObject.CompareTag("Magnet")) {
            if (abilityManager.getSelectedAbility() == "electric" && collision.gameObject.GetComponent<MagnetEnemy>().getIsAlive() == true) {
                TakeDamage(3f, "Magnet");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FireEnemy") && abilityManager.getSelectedAbility() != "ram") {
            TakeDamage(1f, "fire-enemy");
        }
        if (other.gameObject.CompareTag("Water") && abilityManager.getSelectedAbility() == "electric") {
            TakeDamage(10f, "water");
            print("killed by self-electrocution in water");
        }
    }
    
    void Update()
    {

    }

    public void TakeDamage(float damage, string enemy)
    {
        
        if (enemy == "self-stealth" || GetComponent<GhostAbility>().getUsingStealth() == false) {
            string ability = abilityManager.getSelectedAbility();
            print("ability:" + ability + ", health: " + healthLevels[ability]);
            if (healthLevels[ability] > 0)
            {
                ShowDamage[] showDamages = GetComponentsInChildren<ShowDamage>();
                foreach(ShowDamage showDamage in showDamages)
                {
                    showDamage.TurnRed();
                }
                float new_health = healthLevels[ability] - damage;
                healthLevels[ability] = new_health;
            }
            if (healthLevels[ability] <= 0)
            {
                messageToPlayer.DisplayDied();
                Vector2 playerposition = transform.position;
                sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
                gameObject.SetActive(false);
                pmc.isDead = true;
            }
        }
    }
}
