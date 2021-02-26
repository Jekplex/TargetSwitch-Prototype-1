using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    
    public void _PlayAgain()
    {
        SceneManager.LoadScene(0); // currently 0 - game scene | might change.
    }

}
