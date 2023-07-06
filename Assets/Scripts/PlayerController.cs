using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    private float health;
    public float maxLives = 3f;
    public SendToGoogle sendtogoogle;
    private RockEnemy rockEnemy;
    public MessageToPlayer messageToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxLives;
        healthLabel.text = "Health: " + health;
        gameObject.SetActive(true);
        sendtogoogle = GetComponent<SendToGoogle>();

    }

    public float getHealthy()
    {
        return health;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rockEnemy = collision.gameObject.GetComponent<RockEnemy>();
        if (collision.gameObject.CompareTag("RockEnemy") && !rockEnemy.get_is_corpse())
        {
            TakeDamage(1f, "rock");
        }
    }
    
    

    public void TakeDamage(float damage, string enemy)
    {
        if (health > 0)
        {
            health -= damage;
            healthLabel.text = "Health: " + health;
        }
        if (health <= 0)
        {
            messageToPlayer.DisplayDied();
            Vector2 playerposition = transform.position;
            sendtogoogle.Send(System.DateTime.Now, playerposition, enemy);
            gameObject.SetActive(false);
        }
    }
}
