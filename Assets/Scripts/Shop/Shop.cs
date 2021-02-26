using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public Button UnlockShopButton;

    private bool isPaused = false;

    private void Start()
    {
        //OpenShop();
        //SetupShopItemsButtons();
        SetupUnlockShopButton();

        CloseShop();
        isPaused = false;

    }

    private void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            if (!isPaused)
            {
                OpenShop();
            }
            else
            {
                CloseShop();
            }

            isPaused = !isPaused;
        }
    }

    void CloseShop()
    {
        Time.timeScale = 1f;
        shopPanel.GetComponent<Image>().enabled = false;
        shopPanel.transform.GetChild(0).gameObject.gameObject.SetActive(false); // title
        shopPanel.transform.GetChild(1).gameObject.gameObject.SetActive(false); // shop items container
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OpenShop()
    {
        Time.timeScale = 0f;
        shopPanel.GetComponent<Image>().enabled = true;
        shopPanel.transform.GetChild(0).gameObject.gameObject.SetActive(true); // title
        shopPanel.transform.GetChild(1).gameObject.gameObject.SetActive(true); // shop items container
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void SetupUnlockShopButton()
    {
        var listOfAllButtons = UnlockShopButton.gameObject.transform.parent.GetComponentsInChildren<Button>();

        foreach (var button in listOfAllButtons)
        {
            button.interactable = false;
        }

        UnlockShopButton.interactable = true;
    }

    //void SetupUnlockShopButton()
    //{
    //    var listOfAllButtons = UnlockShopButton.gameObject.transform.parent.GetComponentsInChildren<Button>();
    //
    //    foreach (var button in listOfAllButtons)
    //    {
    //        button.interactable = false;
    //    }
    //
    //    UnlockShopButton.interactable = true;
    //}

}
