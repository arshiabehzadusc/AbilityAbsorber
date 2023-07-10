using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public float damage = 1f;
    public float duration = 0.5f;
    public float period = 2f;  // Time interval between each fire
    public GameObject FirePrefab;

    void Start()
    {
        // Start the fire ability coroutine
        StartCoroutine(FireAbilityCoroutine());
    }

    IEnumerator FireAbilityCoroutine()
    {
        while (true)
        {
            Debug.Log("Using fire radius ability");

            // create circle fireball radius
            Vector2 spawnPosition = transform.position;
            GameObject newfire = Instantiate(FirePrefab, spawnPosition, Quaternion.identity);
            newfire.transform.parent = transform; // setting it to follow object
            Destroy(newfire, duration);

            // Wait for the next fire
            yield return new WaitForSeconds(period);
        }
    }
}
