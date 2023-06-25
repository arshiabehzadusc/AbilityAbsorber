using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// reads player input (1, 2, 3) to select ability.
public class AbilityManager : MonoBehaviour
{
    private string selectedAbility = "none"; // can be "fire", "screech", or "ram"
    private Dictionary<string, bool> unlockedAbilities;

    void Start() {
        unlockedAbilities = new Dictionary<string, bool>();
        unlockedAbilities["fire"] = true;
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
        if (Input.GetKeyDown(KeyCode.Alpha1) && unlockedAbilities["fire"]) {
            selectedAbility = "fire";
            Debug.Log("selected ability changed to " + selectedAbility);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && unlockedAbilities["screech"]) {
            selectedAbility = "screech";
            Debug.Log("selected ability changed to " + selectedAbility);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && unlockedAbilities["ram"]) {
            selectedAbility = "ram";
            Debug.Log("selected ability changed to " + selectedAbility);
        }
        
        
    }
}

