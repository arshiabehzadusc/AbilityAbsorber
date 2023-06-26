using System;
using System.Collections;
using UnityEngine;

public class pushback_and_stun : MonoBehaviour
{
    public string objectTag = "Shockwave";
    public float pushForce = 200f;

    private GameObject shockWave;
    private int counter = 0;
    private int pushTime = 2;
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        shockWave = GameObject.FindGameObjectWithTag(objectTag);
        if (other.gameObject == shockWave)
        {
            print("works");
            Vector2 dir = other.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            if (GetComponent<Rigidbody2D>() != null)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().AddForce(dir*pushForce);
            }
            playerMovement.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == shockWave)
        {
            StartCoroutine(Unstun());
        }
    }

    private IEnumerator Unstun()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        playerMovement.enabled = true;
    }
    

}

