using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject shopPanel;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            gameIsPaused = !gameIsPaused;

            if (gameIsPaused)
            {
                Time.timeScale = 0f;
                shopPanel.GetComponent<Image>().enabled = true;
                shopPanel.transform.Find("Shop Items").gameObject.SetActive(true);
                shopPanel.transform.Find("Title").gameObject.SetActive(true);
                playerController.enabled = false;
            }
            else
            {
                Time.timeScale = 1f;
                shopPanel.GetComponent<Image>().enabled = false;
                shopPanel.transform.Find("Shop Items").gameObject.SetActive(false);
                shopPanel.transform.Find("Title").gameObject.SetActive(false);
                playerController.enabled = true;
            }
        }
    }

    public bool getGameIsPaused()
    {
        return gameIsPaused;
    }
}
