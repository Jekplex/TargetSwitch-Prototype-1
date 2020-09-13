using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetImages : MonoBehaviour
{
    private GameMaster gm;

    [SerializeField] private GameObject child_Square;
    [SerializeField] private GameObject child_Triangle;
    [SerializeField] private GameObject child_Circle;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        //gm.playerTarget
        SetDisplayTarget(gm.playerTarget);
    }

    public void SetDisplayTarget(Enemy.EnemyType type)
    {
        switch(type)
        {
            case 0: // square
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i == 0)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {
                        transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
                break;
            case (Enemy.EnemyType)1: // triangle
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i == 1)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {
                        transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
                break;
            case (Enemy.EnemyType)2:
                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i == 2)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {
                        transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
                break;
        }
    }
}
