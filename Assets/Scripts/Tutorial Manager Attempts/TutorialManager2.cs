using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TutorialManager2 : MonoBehaviour
{
    public GameObject WelcomeBanner;
    public GameObject MovementTutBanner;
    public GameObject ExploreRoomTutBanner;
    public GameObject ObjectInteractionTutBanner;
    public GameObject AbilityUseTutBanner;
    public GameObject KillEnemiesTutBanner;
    public AbilityManager abilityManager;

    private HashSet<string> keysPressed = new HashSet<string>();
    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Level 1") // Check your level name here
        {
            StartCoroutine(DisplayBanner(WelcomeBanner));
        }
    }

    private IEnumerator DisplayBanner(GameObject banner)
    {
        Time.timeScale = 0;
        banner.SetActive(true);
        while(!Input.GetKeyDown(KeyCode.Q))
        {
            yield return null;
        }
        banner.SetActive(false);
        Time.timeScale = 1;
        if(banner == WelcomeBanner)
        {
            yield return new WaitForSeconds(3f);
            StartCoroutine(DisplayBanner(MovementTutBanner));
        }
        else if(banner == ObjectInteractionTutBanner)
        {
            if(!abilityManager.unlockedAbilities["fire"])
            {
                StartCoroutine(DisplayBanner(AbilityUseTutBanner));
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            keysPressed.Add(Input.inputString.ToUpper());
            if(keysPressed.Count == 4)
            {
                StartCoroutine(DisplayBanner(ExploreRoomTutBanner));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Room Switch1")
        {
            StartCoroutine(WaitAndDisplayBanner(ObjectInteractionTutBanner, 2f));
        }
        else if(other.gameObject.name == "Room Switch2")
        {
            StartCoroutine(WaitAndDisplayBanner(KillEnemiesTutBanner, 2f));
        }
    }

    private IEnumerator WaitAndDisplayBanner(GameObject banner, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(DisplayBanner(banner));
    }
}
