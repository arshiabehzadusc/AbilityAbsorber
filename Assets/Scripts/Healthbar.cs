using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public PlayerController playerHealth;

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.health;
    }
}







