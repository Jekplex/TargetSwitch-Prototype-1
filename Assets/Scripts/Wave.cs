using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    /*
     * This script allows for the game to turn into a wave style game.
     */

    public bool waveIsOn = false;
    public float waveTime = 10f;
    public float timeInBetweenWaves = 10f;

    [Header("Requirements")]
    public GameMaster gm;
    public GameObject spawner;

    [Header("Private")]
    float timer;
    [SerializeField] bool waveInProgress = false;

    

    private void Start()
    {
        if (waveIsOn)
        {
            timer = waveTime;
            waveInProgress = true;
            gm.isDifficultyScaling = false;
        }
    }

    private void Update()
    {
        if (waveIsOn)
        {
            if (waveInProgress)
            {
                timer -= Time.deltaTime;

                // if timer is up
                if (timer <= 0)
                {
                    waveInProgress = false;

                    timer = timeInBetweenWaves;

                    // disable difficultyscaling & spawning

                    gm.isDifficultyScaling = false;
                    spawner.SetActive(false);
                }
            }
            else
            {
                timer -= Time.deltaTime;

                // if timer is up
                if (timer <= 0)
                {
                    waveInProgress = true;

                    timer = waveTime;

                    // enable difficultyscaling & spawning

                    gm.isDifficultyScaling = true;
                    spawner.SetActive(true);

                }
            }
        }
    }

    //private void EnableWaves

}
