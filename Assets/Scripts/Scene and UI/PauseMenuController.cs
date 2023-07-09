using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI; // Attach your Pause Menu UI to this in inspector
    public GameObject pausePanel; // Attach your Pause Panel to this in inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0; // Pause the game
                pauseMenuUI.SetActive(true); // Show the pause menu
                pausePanel.SetActive(true); // Show the pause panel
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1; // Resume the game
        pauseMenuUI.SetActive(false); // Hide the pause menu
        pausePanel.SetActive(false); // Hide the pause panel
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; // Make sure game is not paused when reloading the level
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName); // Reload the current scene
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1; // Make sure game is not paused when going back to main menu
        SceneManager.LoadScene("Main Menu");
    }
}
