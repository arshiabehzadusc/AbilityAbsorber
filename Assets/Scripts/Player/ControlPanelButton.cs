using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelButton : MonoBehaviour
{
    public GameObject controlTab; // Reference to Controls Tab
    
    private bool isTabVisible; // To track visibility state of Controls Tab
    
    void Start()
    {
        // Initially, we assume Controls Tab is not visible
        isTabVisible = false;
        controlTab.SetActive(isTabVisible);
    }

    public void OnControlPanelClick() // Method to be called on button click
    {
        isTabVisible = !isTabVisible; // Toggle visibility state
        controlTab.SetActive(isTabVisible); // Set the new state
    }
}
