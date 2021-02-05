﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public Enemy.EnemyType playerTarget;
    [SerializeField] private int playerRep;
    public TextMeshProUGUI repUI_valueText;
    [SerializeField] private float enemyMoveSpeed = 1f;
    public Spawner mySpawner;
    public PlayerTargetUISprites playerTargetUISpritesScript;
    [SerializeField] private int numOfEnemyToKill;
    public int maxNumOfEnemyToKill;

    //?
    private bool targetSwitchOn = false;
    [SerializeField] private float enemySpeedScalar = 1.1f;
    //public bool isDifficultyScaling;

    [Header("Sound Sources")]
    public AudioSource TargetSwitchSound;

    [Header("Extras")]
    public GameObject shopPanel;
    private ShopMenu shopPanelScript;

    public float repGainScalar = 1f;

    private void Start()
    {
        //difficultyOffset = 1.00005f;

        shopPanelScript = shopPanel.GetComponent<ShopMenu>();

        // Start scene with cursor locked in window.
        Cursor.lockState = CursorLockMode.Confined;
    }

    public float GetEnemySpeed()
    {
        return enemyMoveSpeed;
    }

    //private int count = 0;
    private bool firstTargetSwitchCycle = true;

    public void EnemyKilled_AddOrRemoveRep(float distance, string enemyType)
    {
        //Debug.Log(distance);
        int rep = Mathf.RoundToInt(distance);

        if (enemyType == playerTarget.ToString())
        {
            playerRep += (int)(rep * repGainScalar);
            numOfEnemyToKill -= 1;

            // Target Switch Mechanic Check - Continue...
            if (numOfEnemyToKill <= 0)
            {
                targetSwitchOn = false;
            }
        }
        else
        {
            playerRep -= (int)(rep * repGainScalar);
        }

        updateUI();
    }

    public int GetRep()
    {
        return playerRep;
    }

    public void removeRep(int amount)
    {
        playerRep -= amount;
        updateUI();
    }

    void updateUI()
    {
        // Update Rep
        repUI_valueText.text = playerRep.ToString();
    }

    void updateExistingEnemiesSpeed()
    {
        // loop through current enemies and update speed.
        for (int i = 0; i < mySpawner.enemyParentObj.transform.childCount; i++)
        {
            mySpawner.enemyParentObj.transform.GetChild(i).GetComponent<Enemy>().SetMoveSpeed(enemyMoveSpeed);
        }
    }

    float storageToStoreTimeDeltaTimeToAllowProperScalingOfEnemySpeed = 0f;

    private void Update()
    {
        storageToStoreTimeDeltaTimeToAllowProperScalingOfEnemySpeed += Time.deltaTime;

        if (storageToStoreTimeDeltaTimeToAllowProperScalingOfEnemySpeed >= 0.5f)
        {
            if (shopPanelScript.GetGameIsPaused() == false)
            {
                enemyMoveSpeed *= enemySpeedScalar;
                mySpawner.spawnRate /= enemySpeedScalar;
                updateExistingEnemiesSpeed();
                Debug.Log(enemyMoveSpeed);
                
            }
            
            storageToStoreTimeDeltaTimeToAllowProperScalingOfEnemySpeed = 0f; //reset
        }
        

        
        

        if (!targetSwitchOn)
        {
            targetSwitchOn = true;

            // Play "You're doing good sound" here...
            //count++;
            if (firstTargetSwitchCycle)
            {
                firstTargetSwitchCycle = false;
            }
            else
            {
                TargetSwitchSound.Play();
            }

            // Setup for number of targets the player will have to destroy.
            numOfEnemyToKill = UnityEngine.Random.Range(1, maxNumOfEnemyToKill+1); // 1-5 (inclusive)

            SetDifferentTarget(); 
            // Not ideal because can be executed N number of times until result is not the same as current.
            // Theres definately a better way to do this.

        }
               

    }
    
    //void TargetSwitch
    void SetDifferentTarget()
    {
        int temp = UnityEngine.Random.Range(0, 3); // One or two - Square or Triangle.
        switch (temp)
        {
            case 0:
                if (playerTarget == Enemy.EnemyType.Square)
                {
                    SetDifferentTarget();
                }
                else
                {
                    playerTarget = Enemy.EnemyType.Square;
                }
                break;
            case 1:
                if (playerTarget == Enemy.EnemyType.Triangle)
                {
                    SetDifferentTarget();
                }
                else
                {
                    playerTarget = Enemy.EnemyType.Triangle;
                }
                break;
            case 2:
                if (playerTarget == Enemy.EnemyType.Circle)
                {
                    SetDifferentTarget();
                }
                else
                {
                    playerTarget = Enemy.EnemyType.Circle;
                }
                break;
                //playerTarget = Enemy.EnemyType.Circle;
            default:
                break;
        }
        playerTargetUISpritesScript.SetDisplayTarget(playerTarget);
    }

}
