using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAbility : MonoBehaviour
{

    private AbilityManager abilityManager;
    private Rigidbody2D player;
    private bool usingStealth = false;
    private Coroutine myCoroutine;

    public bool getUsingStealth() {
        return usingStealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        abilityManager = GetComponent<AbilityManager>();
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Start coroutine when spacebar is held down
        if (Input.GetKeyDown(KeyCode.Space) && abilityManager.getSelectedAbility() == "stealth")
        {
            usingStealth = true;
            myCoroutine = StartCoroutine(DecreaseHealthGradually());
        }
        
        // Stop coroutine when spacebar is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            usingStealth = false;
            StopCoroutine(myCoroutine);
        }
    }

    IEnumerator DecreaseHealthGradually()
    {
        while (usingStealth)
        {
            GetComponent<PlayerController>().TakeDamage(0.03f, "self-stealth");
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
