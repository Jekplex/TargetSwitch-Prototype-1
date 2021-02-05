using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRightClickIndicator : MonoBehaviour
{

    [Header("Requirements")]
    private GameMaster gm;

    public GameObject GameMaster;
    public GameObject Spawner;

    private void Start()
    {
        gm = GameMaster.GetComponent<GameMaster>();
    }

    bool hasAlreadyIndicated = false;
    bool spawnAndGmBackOn = false;

    private void Update()
    {
        
        if (gm.GetRep() >= 100 && !hasAlreadyIndicated)
        {
            DisableSpawnerAndGameMaster();
            GetComponent<Animator>().SetBool("isBlinking", true);
            hasAlreadyIndicated = true;
        }
    }

    void DisableSpawnerAndGameMaster()
    {
        GameMaster.SetActive(false);
        Spawner.SetActive(false);
    }

    public void EnableSpawnerAndGameMaster()
    {
        GameMaster.SetActive(true);
        Spawner.SetActive(true);
    }

}
