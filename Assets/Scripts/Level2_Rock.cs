using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Rock : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;             // Adjust the speed of the enemy
    public float jitterRange = 1f;       // Adjust the range of jitter motion

    private Vector2 targetPosition;      // The target position for the next movement
    private Rigidbody2D rb;
    public bool isLeft;
    public float rotationSpeed = 200f;

    private bool is_corpse = false;

    private float health;
    private Vector2 direction;
    public float maxLives = 3f;
    public Renderer renderer;
    public GameObject player;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxLives;
    }

    private void Start()
    {
        // Set the initial target position
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (is_corpse == false)
        {
            Vector2 player_position = player.transform.position;
            if (Vector2.Distance(transform.position, player_position) <= 10f)
            {
                direction = (player_position - (Vector2)transform.position).normalized;
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }

        }
    }

        
    // EVERY ENEMY NEAR GLUE SHOULD HAVE THIS METHOD
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Glue")) {
            Debug.Log("Rock stuck in glue");
            speed = 0.3f;
        }
    }


    public void TakeDamage(float damage)
    {
        // reset speed
        speed = 2f;

        if (health > 0)
        {
            health -= damage;
            print(health);
        }
        if (health <= 0)
        {
            // Destroy object - gameObject.SetActive(false);

            // make into corpse
            Debug.Log("killed rock");
            is_corpse = true;
            rb.velocity = new Vector2(0f, 0f);
            Color color = HexToColor("372E2E");
            renderer.material.color = color;
        }
        
    }

    public bool getIsCorpse()
    {
        return is_corpse;
    }

    private Color HexToColor(string hex)
    {
        Color color = Color.black;
        ColorUtility.TryParseHtmlString("#" + hex, out color);
        return color;
    }
}
