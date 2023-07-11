using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    public GameObject level2CompleteUI;
    public GameObject level2Exit;
    public GameObject player;
    private NewGhostEnemy ghostEnemy;
    private SendToGoogle sendtogoogle;
    //private RockEnemy rockEnemyScript;

    void Start()
    {
       ghostEnemy = GetComponent<NewGhostEnemy>();
    }


    // This function is called when the collision into level2 exit trigger at the end of room4
   //function which checks whether win criteria for level 2 is satisfied
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             if (ghostEnemy.getIsCorpse() == true)
            {
                sendtogoogle.Send(System.DateTime.Now, transform.position, "WIN");
                level2CompleteUI.SetActive(true);
            }
        }
    }

    public void GoToMainMenu()
    {
       SceneManager.LoadScene("Main Menu");
    }

    public void GoToNextLevel()
    {
       SceneManager.LoadScene("Level 3");
    }



}