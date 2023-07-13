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
        abilityManager.switchAbility("fire");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Fire ability activated");

        //Find and delete the "Megaphone" game object
        GameObject toRemoveObject = GameObject.Find("Megaphone");
        if (toRemoveObject != null)
        {
            Destroy(toRemoveObject);
            Debug.Log("Megaphone gameobject deleted");
        }
        else
        {
            Debug.Log("No gameobject named Megaphone found");
        }
        
    }

    public void SelectBatAbility()
    {
        abilityManager.selectedAbility = "screech";
        abilityManager.abilityInventory.Add("screech");
        abilityManager.switchAbility("screech");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Screech ability activated");

         //Find and delete the "Dynamite" game object
        GameObject toRemoveObject = GameObject.Find("Dynamite1");
        if (toRemoveObject != null)
        {
            Destroy(toRemoveObject);
            Destroy(GameObject.Find("Dynamite2"));
            Debug.Log("Dynamite gameobject deleted");
        }
        else
        {
            Debug.Log("No gameobject named Dynamite found");
        }
    }

     public void SelectRamAbility()
    {
        abilityManager.selectedAbility = "ram";
        abilityManager.abilityInventory.Add("ram");
        abilityManager.switchAbility("ram");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Ram ability activated");
    }

      public void SelectStealthAbility()
    {
        abilityManager.selectedAbility = "stealth";
        abilityManager.abilityInventory.Add("stealth");
        abilityManager.switchAbility("stealth");
        abilityChoicePanel.SetActive(false);
        Debug.Log("Stealth ability activated");
    }
    

}
