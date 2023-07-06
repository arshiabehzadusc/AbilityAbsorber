using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBat : MonoBehaviour
{
    public GameObject Torch1;
    public GameObject Torch2;

    private Bat bossBat;

    // Start is called before the first frame update
    void Start()
    {
        bossBat = GetComponent<Bat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossBat.getIsCorpse()) {
            Torch1.SetActive(true);
            Torch2.SetActive(true);

        }
    }
}
