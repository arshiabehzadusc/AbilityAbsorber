using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    public GameObject level2CompleteUI;
    
    public GameObject level2Exit;
    public GameObject player;
    private SendToGoogle sendtogoogle;
    //private RockEnemy rockEnemyScript;

    void Start()
    {
        sendtogoogle = player.GetComponent<SendToGoogle>();
        // Assumes RockEnemy script is attached to the same GameObject
        // rockEnemyScript = GetComponent<RockEnemy>();

        /* if (rockEnemyScript == null)
         {
             Debug.LogError("No RockEnemy script found on this GameObject.");
         }*/
    }


    // This function is called when the GameObject this script is attached to collides with another GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             if (torchFire1.activeInHierarchy && torchFire2.activeInHierarchy)
            {
                sendtogoogle.Send(System.DateTime.Now, transform.position, "WIN");
                level1CompleteUI.SetActive(true);
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
