using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// reads player input (1, 2, 3) to select ability.
public class AbilityManager : MonoBehaviour
{
    private string selectedAbility = "none"; // can be fire, screech, glue, ram
    public Dictionary<string, bool> unlockedAbilities;//changed from private to public so that TutorialManager script can check if ability was obtained
    public float absorbRadius = 2f;
    public GameObject MessageToPlayer;
    public GameObject flame; 
    public GameObject flare; 
    public GameObject batForm;
    public GameObject glueForm;
    public GameObject UIActiveBat;
    public GameObject UIActiveFire;
    private PlayerController playerController;
    public Healthbar healthBar;
    void Start() {
        unlockedAbilities = new Dictionary<string, bool>();
        unlockedAbilities["fire"] = false;
        unlockedAbilities["screech"] = false;
        unlockedAbilities["glue"] = false;
        unlockedAbilities["ram"] = false;
        playerController = GetComponent<PlayerController>();
        
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
            // set everything to fire
            selectedAbility = "fire";
            Debug.Log("selected ability changed to " + selectedAbility);
            flare.SetActive(true);
            flame.SetActive(true);
            UIActiveFire.SetActive(true);
            healthBar.setHealthBar("fire");

            // set all others false
            batForm.SetActive(false);
            UIActiveBat.SetActive(false);
            playerController.isBat = false;
            glueForm.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedAbilities["screech"]) {
            // set everything to screech/bat
            selectedAbility = "screech";
            Debug.Log("selected ability changed to " + selectedAbility);
            batForm.SetActive(true);
            playerController.isBat = true;
            healthBar.setHealthBar("bat"); 
            UIActiveBat.SetActive(true);

            // set all others false
            flare.SetActive(false);
            flame.SetActive(false);
            UIActiveFire.SetActive(false);
            glueForm.SetActive(false);
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedAbilities["glue"]) {
            // set everything to glue
            selectedAbility = "glue";
            Debug.Log("selected ability changed to " + selectedAbility);
            glueForm.SetActive(true);
            healthBar.setHealthBar("glue");

            //set all others false
            flare.SetActive(false);
            flame.SetActive(false);
            playerController.isBat = false;
            batForm.SetActive(false);
            UIActiveBat.SetActive(false);

            
        }


        // Absorb ability
        if (Input.GetKeyDown(KeyCode.E)) {
            checkNearbyAbilityAvailable("Campfire", "fire");
            checkNearbyAbilityAvailable("BatEnemy", "screech");
            checkNearbyAbilityAvailable("Glue", "glue");
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
                if (ability.Equals("glue"))
                    messageToPlayer.DisplayAbilityUnlocked("glue", 3);
            }
        }
    }
}

