using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRepMiner : MonoBehaviour
{
    
    public float numOfSecondsForTimeInbetweenEachPopOfRep = 1f;
    public int autoRepLevel = 1;

    private float numOfSecondsUntilPopOfRep;

    [Header("Required")]
    public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        numOfSecondsUntilPopOfRep = numOfSecondsForTimeInbetweenEachPopOfRep;
    }

    // Update is called once per frame
    void Update()
    {
        numOfSecondsUntilPopOfRep -= Time.deltaTime;

        if (numOfSecondsUntilPopOfRep <= 0)
        {
            PopRep();

            //reset
            numOfSecondsUntilPopOfRep = numOfSecondsForTimeInbetweenEachPopOfRep;
        }
    }

    void PopRep()
    {
        int numOfRepPopped = Random.Range(1, 10 * autoRepLevel);
        gm.addRep(numOfRepPopped);

        // we need a notification for this.
    }
}
