using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject welcomeBanner;
    public GameObject movementTutBanner;
    public GameObject exploreRoomTutBanner;
    public GameObject objectInteractionTutBanner;
    public GameObject abilityUseTutBanner;
    public GameObject killEnemiesTutBanner;
    
    private bool[] wasdPressed = new bool[4];

    private AbilityManager abilityManager;

    private void Start()
    {
        abilityManager = GetComponent<AbilityManager>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (welcomeBanner.activeInHierarchy || movementTutBanner.activeInHierarchy ||
            exploreRoomTutBanner.activeInHierarchy || objectInteractionTutBanner.activeInHierarchy ||
            abilityUseTutBanner.activeInHierarchy || killEnemiesTutBanner.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ResumeGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.W)) wasdPressed[0] = true;
        if (Input.GetKeyDown(KeyCode.A)) wasdPressed[1] = true;
        if (Input.GetKeyDown(KeyCode.S)) wasdPressed[2] = true;
        if (Input.GetKeyDown(KeyCode.D)) wasdPressed[3] = true;

        if (wasdPressed[0] && wasdPressed[1] && wasdPressed[2] && wasdPressed[3] && !exploreRoomTutBanner.activeInHierarchy)
        {
            PauseGame(exploreRoomTutBanner);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level 1")
        {
            PauseGame(welcomeBanner);
            StartCoroutine(ShowMovementBanner());
        }
    }

    private IEnumerator ShowMovementBanner()
    {
        yield return new WaitForSeconds(3);
        PauseGame(movementTutBanner);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Room Switch1")
        {
            StartCoroutine(ShowObjectInteractionBanner());
        }
        else if (collision.gameObject.name == "Room Switch2")
        {
            StartCoroutine(ShowKillEnemiesBanner());
        }
    }

    private IEnumerator ShowObjectInteractionBanner()
    {
        yield return new WaitForSeconds(2);
        PauseGame(objectInteractionTutBanner);
    }

    private IEnumerator ShowKillEnemiesBanner()
    {
        yield return new WaitForSeconds(2);
        PauseGame(killEnemiesTutBanner);
    }

    private void PauseGame(GameObject banner)
    {
        Time.timeScale = 0;
        banner.SetActive(true);
        if (!abilityManager.unlockedAbilities["fire"] && banner == objectInteractionTutBanner)
        {
            abilityUseTutBanner.SetActive(true);
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        welcomeBanner.SetActive(false);
        movementTutBanner.SetActive(false);
        exploreRoomTutBanner.SetActive(false);
        objectInteractionTutBanner.SetActive(false);
        abilityUseTutBanner.SetActive(false);
        killEnemiesTutBanner.SetActive(false);
    }
}
