using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// reads player input (1, 2, 3) to select ability.
public class AbilityManager : MonoBehaviour
{
    private string selectedAbility = "none"; // can be "fire", "screech", or "ram"
    public Dictionary<string, bool> unlockedAbilities;//changed from private to public so that TutorialManager script can check if ability was obtained
    public float absorbRadius = 2f;
    public GameObject MessageToPlayer;
    public GameObject flame; 
    public GameObject flare; 
    public GameObject batForm;
    public GameObject UIActiveBat;
    public GameObject UIActiveFire;

    void Start() {
        unlockedAbilities = new Dictionary<string, bool>();
        unlockedAbilities["fire"] = false;
        unlockedAbilities["screech"] = false;
        unlockedAbilities["ram"] = false;
    }

    public string getSelectedAbility() {
        return selectedAbility;
    }

    public bool getUnlockedAbility(string abilityInQuestion) {
        return unlockedAbilities[abilityInQuestion];
    }

    

    void Update() {

        // Select ability
        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedAbilities["fire"]) {
            selectedAbility = "fire";
            batForm.SetActive(false);
            UIActiveBat.SetActive(false);
            flare.SetActive(true);
            flame.SetActive(true);
            UIActiveFire.SetActive(true);

            Debug.Log("selected ability changed to " + selectedAbility);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedAbilities["screech"]) {
            selectedAbility = "screech";
            Debug.Log("selected ability changed to " + selectedAbility);
            flare.SetActive(false);
            flame.SetActive(false);
            UIActiveFire.SetActive(false);
            batForm.SetActive(true);
            UIActiveBat.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedAbilities["ram"]) {
            selectedAbility = "ram";
            Debug.Log("selected ability changed to " + selectedAbility);
            flare.SetActive(false);
            flame.SetActive(false);
        }


        // Absorb ability
        if (Input.GetKeyDown(KeyCode.E)) {
            checkNearbyAbilityAvailable("Campfire", "fire");
            checkNearbyAbilityAvailable("BatEnemy", "screech");
           // checkNearbyAbilityAvailable("RockEnemy", "ram");
        }

        
        
    }

    // for example, check if campfire is nearby enough to absorb fire ability
    void checkNearbyAbilityAvailable(string tag, string ability) {
        Vector3 positionToCheck = transform.position;
        GameObject[] campfireObjects = GameObject.FindGameObjectsWithTag(tag); // Find objects by tag

        foreach (GameObject campfireObject in campfireObjects)
        {
            Vector3 campfirePosition = campfireObject.transform.position;
            float distance = Vector3.Distance(positionToCheck, campfirePosition);

            if (distance <= absorbRadius)
            {
                unlockedAbilities[ability] = true;
                MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                
                if (ability.Equals("fire"))
                    messageToPlayer.DisplayAbilityUnlocked("fire", 1);
                if (ability.Equals("screech"))
                    messageToPlayer.DisplayAbilityUnlocked("screech", 2);
                if (ability.Equals("ram"))
                    messageToPlayer.DisplayAbilityUnlocked("ram", 3);
            }
        }
    }
}

