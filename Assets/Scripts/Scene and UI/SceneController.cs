using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Function called when Start button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    // Function called when Options button is pressed
    public void Options()
    {
        // For now, we're not doing anything here
    }

    // Function called when Quit button is pressed
    public void QuitGame()
    {
        //If we are running in a standalone build of the game
	#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
	#endif

		//If we are running in the editor
	#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
	#endif
    }
}
