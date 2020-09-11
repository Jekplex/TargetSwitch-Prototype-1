using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    //public enum EnemyDirection
    //{
    //    TopToBottom,
    //    BottomToTop,
    //    RightToLeft,
    //    LeftToRight
    //}

    // For now we'll only be using TopToBottom.
    // The rest is completely experimental and may or may not be used in final build.

    //public EnemyDirection myEnemyDirection;

    public Enemy.EnemyType playerTarget;

    [SerializeField] private int playerRep;

    public TextMeshProUGUI Rep_ValueText;

    public float enemyMoveSpeed = 1f; //3f to 10f maybe

    public Spawner mySpawner;

    //public GameObject UI_TargetPanel;
    public TargetImages TargetImagesScript;

    private bool targetSwitchOn = false;


    public void addRep(int rep, string enemyType)
    {
        if (enemyType == playerTarget.ToString())
        {
            playerRep += rep;
        }
        else
        {
            playerRep -= rep;
        }

        updateUI();
    }

    void updateUI()
    {
        // Update Rep
        Rep_ValueText.text = playerRep.ToString();
    }

    void updateEnemySpeed() // We only want to use this when EnemyMoveSpeed is changed. // Using it every frame wouldn't be effcient.
    {
        // loop through current enemies and set speed.

        //mySpawner.enemyParentObj.transform.GetChild;

        for (int i = 0; i < mySpawner.enemyParentObj.transform.childCount; i++)
        {
            mySpawner.enemyParentObj.transform.GetChild(i).GetComponent<Enemy>().SetMoveSpeed(enemyMoveSpeed);
        }

        //mySpawner.enemyParentObj;
    }

    private void Update()
    {
        enemyMoveSpeed *= 1.0001f;
        mySpawner.spawnRate /= 1.0001f;

        // the fast enemy moveSpeed gets the fast spawnrate has to go aswell.
        // or else it feels like it's spawning only one that moves fast.
        // this doesn't force the player to move in W and S direction making moving up and down completely reduntant.

        updateEnemySpeed();

        // TODO: Implement that actual target switching.

        if (!targetSwitchOn)
        {
            StartCoroutine(SwitchTarget(5f));
        }
    }

    IEnumerator SwitchTarget(float seconds)
    {

        targetSwitchOn = true;

        // Every 5s switch targets (maybe?)
        yield return new WaitForSeconds(seconds);

        
        int temp = UnityEngine.Random.Range(0, 2); // One or two - Square or Triangle.
        switch (temp)
        {
            case 0:
                playerTarget = Enemy.EnemyType.Square;
                break;
            case 1:
                playerTarget = Enemy.EnemyType.Triangle;
                break;
            default:
                break;
        }

        // Change Target Image Respectfully.
        TargetImagesScript.SetDisplayTarget(playerTarget);

        targetSwitchOn = false;

    }
}
