using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playerHealth;

    private string ability;
    // Update is called once per frame

    private void Start()
    {
        ability = "none";
    }

    void Update()
    {
        slider.value = playerHealth.healthLevels[ability];
    }

    public void setHealthBar(string ability, float maxHealth)
    {
        this.ability = ability;
        slider.maxValue = maxHealth;
        RectTransform backgroundRT = slider.transform.Find("Background").GetComponent<RectTransform>();
        RectTransform fillAreaRT = slider.transform.Find("Fill Area").GetComponent<RectTransform>();
        backgroundRT.offsetMax = new Vector2(25 * maxHealth, backgroundRT.offsetMax.y); // -50 is the new "right" value, keep the original "top" value
        fillAreaRT.offsetMax = new Vector2(25 * maxHealth, fillAreaRT.offsetMax.y);

    }
}






