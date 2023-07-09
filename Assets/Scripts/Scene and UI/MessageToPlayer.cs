using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUI;
    public GameObject arrow;

    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayAbilityUnlocked(string new_ability, int slot)
    {
        Debug.Log("unlocked ability");
        textMeshProUI.text = "Unlocked: " + new_ability.ToUpper() + "\nPress " + slot.ToString() + " to equip";
        arrow.SetActive(true);
        Invoke("Clear", 3f);
        Invoke("HideArrow", 3f); // Set arrow to inactive after 3 seconds
    }

    public void DisplayDied()
    {
        Debug.Log("player died");
        textMeshProUI.text = "You died\nPress Esc";
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
