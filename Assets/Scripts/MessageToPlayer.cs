using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUI;

    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayAbilityUnlocked(string new_ability, int slot)
    {
        Debug.Log("unlocked ability");
        textMeshProUI.text = "Unlocked: " + new_ability.ToUpper() + "\nPress " + slot.ToString() + " to equip.";
        Invoke("Clear", 3f);
    }
    public void DisplayDied() {
        Debug.Log("player died");
        textMeshProUI.text = "You died\nPress Esc";
        //Invoke("Clear", 3f);
    }



    private void Clear() {
        textMeshProUI.text = "";
    }
}
