using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Fire")) {
            // create circle fireball radius
            Vector2 spawnPosition = transform.position;
            GameObject newfire = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            Destroy(newfire, 2f);
        }
    }
}
