using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickIndicator : MonoBehaviour
{

    [Header("Requirements")]
    public GameMaster gm;

    private void Start()
    {
        
    }

    bool hasAlreadyIndicated = false;

    private void Update()
    {
        
        if (gm.GetRep() >= 100 && !hasAlreadyIndicated)
        {
            GetComponent<Animator>().SetBool("isBlinking", true);
            hasAlreadyIndicated = true;
        }

    }


}
