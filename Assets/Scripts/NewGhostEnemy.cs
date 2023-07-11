using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGhostEnemy : MonoBehaviour
{
    private float maxLives = 3f;
    public float roamDuration = 4f;
    public float dashSpeed = 5f;
    public float roamSpeed = 2f;
    public GameObject player;
    public Vector2 roamAreaMin, roamAreaMax;
    public bool is_corpse = false; 
    private float health;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 roamPosition;
    private AbilityManager abilityManager;
    private RockAbility rockAbility;
    public GameObject tombstonePrefab; // Add this

    void Start()
    {
        health = maxLives;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        abilityManager = GetComponent<AbilityManager>();
        rockAbility = GetComponent<RockAbility>();
        spriteRenderer.enabled = false;
        StartCoroutine(GhostStateMachine());
    }

    IEnumerator GhostStateMachine()
    {
        while (true)
        {
            yield return Roam();
            yield return Dash();
        }
    }

    IEnumerator Roam()
    {
        spriteRenderer.enabled = false;
        roamPosition = new Vector2(
            Random.Range(roamAreaMin.x, roamAreaMax.x),
            Random.Range(roamAreaMin.y, roamAreaMax.y)
        );

        float startTime = Time.time;
        while (Time.time < startTime + roamDuration)
        {
            Vector2 direction = (roamPosition - (Vector2)transform.position).normalized;
            rb.velocity = direction * roamSpeed;
            yield return null;
        }
    }

    IEnumerator Dash()
    {
        spriteRenderer.enabled = true;
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
        rb.velocity = direction * dashSpeed;
        yield return new WaitForSeconds(1);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && abilityManager.getSelectedAbility() == "ram" && rockAbility.isRushing == true)
        {   Debug.Log("Ghost collided with player.");
            Debug.Log("Player dealt damage to ghost by ramming");
            TakeDamage(1.0f);
        }
    }
    */

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            Debug.Log("Ghost health: " + health);
        }

        if (health <= 0)
        {
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            Debug.Log("Ghost killed");
            
            is_corpse = true;
            rb.velocity = new Vector2(0f, 0f);
            spriteRenderer.enabled = false;
            this.enabled = false; // disable this script
            // Spawn tombstone
            if (tombstonePrefab != null)
            {
                Instantiate(tombstonePrefab, transform.position, Quaternion.identity);
            }

            // Disable the ghost object
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // EVERY ENEMY NEAR GLUE SHOULD HAVE THIS GLUE
        if (collision.gameObject.CompareTag("Glue"))
        {
            Debug.Log("Rock stuck in glue");
            speed = 0.3f;
        }
    }

    public bool getIsCorpse()
    {
        return is_corpse;
    }
}