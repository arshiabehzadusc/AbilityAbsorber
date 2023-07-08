using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Complete : MonoBehaviour
{
    public GameObject level3CompleteUI;
    public GameObject level3Exit;
    public GameObject player;
    
    //private RockEnemy rockEnemyScript;

    void Start()
    {
       
    }


    // This function is called when the collision into level2 exit trigger at the end of room4
   //function which checks whether win criteria for level 2 is satisfied

    public void GoToMainMenu()
    {
       SceneManager.LoadScene("Main Menu");
    }

    public void GoToNextLevel()
    {
       SceneManager.LoadScene("Level 4");
    }



}