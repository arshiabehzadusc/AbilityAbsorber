using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEnemy : MonoBehaviour
{

    public float attractionForce; // Strength of the attraction force
    public float radius;
    public float durationOfAttract;
    public float gapBetweenAttracts;
    public GameObject magnetRadiusPrefab;
    
    private bool isAlive = true;
    private bool usingAbility = false;

    private GameObject newradius;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttractRoutine());
    }

    private IEnumerator AttractRoutine()
    {
        while (isAlive)
        {
            Debug.Log("using magnet radius ability");
 
            // create circle magnet radius
            Vector2 spawnPosition = transform.position;
            newradius = Instantiate(magnetRadiusPrefab, spawnPosition, Quaternion.identity);
            newradius.transform.parent = transform;
            Destroy(newradius, durationOfAttract);
            
            // Wait for the next
            yield return new WaitForSeconds(durationOfAttract + gapBetweenAttracts);
        }
    }

    void FixedUpdate()
    {
        if (newradius != null && !ReferenceEquals(newradius, null)) {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius); // Adjust the radius as needed

            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    Vector2 direction = transform.position - collider.transform.position;
                    collider.attachedRigidbody.AddForce(direction.normalized * attractionForce);
                }
            }
        }
        
    }
}
