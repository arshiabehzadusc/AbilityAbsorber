using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUI;
    public GameObject arrow;
    public GameObject FireAbilityInfo;
    public GameObject BatAbilityInfo;
    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayAbilityUnlocked(string new_ability, int slot)
    {
        Debug.Log("unlocked ability");
        textMeshProUI.text = "Unlocked: " + new_ability.ToUpper() + "\nPress " + slot.ToString() + " to equip";
        arrow.SetActive(true);
        if(new_ability=="fire")
        {
            FireAbilityInfo.SetActive(true);
            Invoke("HideFireAbilityInfo", 4f); // Set FireAbilityInfo to inactive after 4 seconds
        }
        if(new_ability=="screech")
        {
            BatAbilityInfo.SetActive(true);
            Invoke("HideBatAbilityInfo", 4f); // Set BatAbilityInfo to inactive after 4 seconds
        }
        Invoke("Clear", 3f);
        Invoke("HideArrow", 3f); // Set arrow to inactive after 3 seconds
    }

    private void HideFireAbilityInfo()
    {
        FireAbilityInfo.SetActive(false);
    }

    private void HideBatAbilityInfo()
    {
        BatAbilityInfo.SetActive(false);
    }


    public void DisplayDied()
    {
        Debug.Log("player died");
        textMeshProUI.text = "You died\nPress R to Restart\nPress P for pause menu";
        //Invoke("Clear", 3f);
    }

    private void Clear()
    {
        textMeshProUI.text = "";
    }

    private void HideArrow()
    {
        arrow.SetActive(false);
    }
}
