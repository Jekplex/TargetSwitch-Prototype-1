using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject shopPanel;
    public PlayerController playerController;
    public GameMaster gm;
    
    public GameObject rci;
    Animator anim_rci;

    // Start is called before the first frame update
    void Start()
    {
        CloseShop();

        anim_rci = rci.GetComponent<Animator>();
    }

    void CloseShop()
    {
        Time.timeScale = 1f;
        shopPanel.GetComponent<Image>().enabled = false;
        shopPanel.transform.Find("Shop Items").gameObject.SetActive(false);
        shopPanel.transform.Find("Title").gameObject.SetActive(false);
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OpenShop()
    {
        Time.timeScale = 0f;
        shopPanel.GetComponent<Image>().enabled = true;
        shopPanel.transform.Find("Shop Items").gameObject.SetActive(true);
        shopPanel.transform.Find("Title").gameObject.SetActive(true);
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (!gameIsPaused)
            {
                if (anim_rci.GetBool("isBlinking"))
                {
                    anim_rci.SetBool("isBlinking", false);
                    anim_rci.gameObject.GetComponent<RightClickIndicator>().EnableSpawnerAndGameMaster();
                }

                OpenShop();
            }
            else
            {
                CloseShop();
            }

            gameIsPaused = !gameIsPaused;
        }
    }

    public bool GetGameIsPaused()
    {
        return gameIsPaused;
    }

}

