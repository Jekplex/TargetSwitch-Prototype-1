using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickIndicator : MonoBehaviour
{
    private GameMaster gm;
    private GameObject gm_obj;
    public GameObject targetSpawner;

    private void Start()
    {
        gm_obj = GameObject.FindGameObjectWithTag("GameMaster");
        gm = gm_obj.GetComponent<GameMaster>();
    }

    bool isFirstTrigger = true;
    bool spawnAndGmBackOn = false;

    private void Update()
    {
        
        if (gm.GetRep() >= 100 && isFirstTrigger)
        {
            triggerIndicator();
            isFirstTrigger = false;
        }

        if (Time.timeScale < 1f)
        {
            disableIndicator();
        }
    }

    void DisableSpawnerAndGameMaster()
    {
        gm_obj.SetActive(false);
        targetSpawner.SetActive(false);
    }

    public void EnableSpawnerAndGameMaster()
    {
        gm_obj.SetActive(true);
        targetSpawner.SetActive(true);
    }

    public void triggerIndicator()
    {
        DisableSpawnerAndGameMaster();
        GetComponent<Animator>().SetBool("isBlinking", true);
    }

    public void disableIndicator()
    {
        EnableSpawnerAndGameMaster();
        GetComponent<Animator>().SetBool("isBlinking", false);
    }

}
