using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveAbility : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshProUI;
    public GameObject Player;
    private AbilityManager abilityManager;

    void Start()
    {
        textMeshProUI = GetComponent<TextMeshProUGUI>();
        abilityManager = Player.GetComponent<AbilityManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUI.text = "Equipped ability: \n" + abilityManager.getSelectedAbility().ToUpper();
    }
}
