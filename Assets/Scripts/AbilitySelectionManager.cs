using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionManager : MonoBehaviour
{
    private string selectedAbility;
    public GameObject abilityChoicePanel;
    private AbilityManager abilityManager;

    void Start() 
    {
        abilityManager = GetComponent<AbilityManager>();
    
    }
        

    public void SelectFireAbility()
    {
        abilityManager.selectedAbility = "fire";
        abilityManager.abilityInventory.Add("fire");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Fire ability activated");
    }

    public void SelectBatAbility()
    {
        abilityManager.selectedAbility = "screech";
        abilityManager.abilityInventory.Add("screech");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Screech ability activated");
    }

     public void SelectRamAbility()
    {
        abilityManager.selectedAbility = "ram";
        abilityManager.abilityInventory.Add("ram");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Ram ability activated");
    }

      public void SelectStealthAbility()
    {
        abilityManager.selectedAbility = "stealth";
        abilityManager.abilityInventory.Add("stealth");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Stealth ability activated");
    }
    

}
