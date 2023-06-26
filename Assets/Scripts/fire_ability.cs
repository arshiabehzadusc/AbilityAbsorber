using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ability : MonoBehaviour
{
    
    public float damage = 1f;
    public float duration = 0.5f;
    private AbilityManager abilityManager;
    private Rigidbody2D player;
    public GameObject FirePrefab;

    void Start()
    {
        abilityManager = GetComponent<AbilityManager>();
        player = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && abilityManager.getSelectedAbility() == "fire")
        {
            Debug.Log("Using fire radius ability");

            // create circle fireball radius
            Vector2 spawnPosition = transform.position;
            GameObject newfire = Instantiate(FirePrefab, spawnPosition, Quaternion.identity);
            newfire.transform.parent = transform; // setting it to follow player
            Destroy(newfire, duration);

        }
    }
}
