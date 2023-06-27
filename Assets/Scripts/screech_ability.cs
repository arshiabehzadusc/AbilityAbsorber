using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screech_ability : MonoBehaviour
{
    private AbilityManager abilityManager;
    private GameObject waveObject;
    private PlayerMovement playerMovement;
    public GameObject shockWave;
    public Transform shockWaveSpawn;

    // Start is called before the first frame update
    void Start()
    {
        abilityManager = GetComponent<AbilityManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && abilityManager.getSelectedAbility() == "screech")
        {
            if (waveObject == null)
            {
                Vector3 spawnPosition = shockWaveSpawn.position;
                waveObject = Instantiate(shockWave, spawnPosition, Quaternion.identity);
            }
        }

        if (waveObject != null)
        {
            waveObject.transform.position = shockWaveSpawn.position;
            if (!playerMovement.isMovingLeft)
            {
                // Flip the sprite to face right
                waveObject.transform.localScale = new Vector3(3f, 3f, 1f);
            }
            else
            {
                // Flip the sprite to face left
                waveObject.transform.localScale = new Vector3(-3f, 3f, 1f);
            }
            Destroy(waveObject, 3f);
        }
    }
}
