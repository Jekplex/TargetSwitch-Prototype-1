using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopHandler : MonoBehaviour
{
    public GameMaster gm;
    public PlayerController playerController;

    [Header("Unlock Shop")]
    public Button unlockShopButton;
    public int unlockShopPrice;

    [Header("Upgrade Movement")]
    public Button upgradeMovementButton;
    public int upgradeMovementPrice;

    [Header("Install AutoRep")]
    public Button installAutoRepButton;
    public int installAutoRepPrice;
    public GameObject autoRepGeneratorObject;

    [Header("Complete Game")]
    public Button completeGameButton;
    public int completeGamePrice;


    //List<Button> upgradeButtons;

    private void Start()
    {
        unlockShopButton.interactable = true;
        upgradeMovementButton.interactable = false;
        installAutoRepButton.interactable = false;
        completeGameButton.interactable = false;

        autoRepGeneratorObject.SetActive(false);

        // setup upgrade button list
        //upgradeButtons.Add(upgradeMovementButton);
        //upgradeButtons.Add(installAutoRepButton);
        //upgradeButtons.Add(completeGameButton);

    }

    private void Update()
    {
        CompleteGameCheckAndResolve();
    }

    public void UnlockShopFunction()
    {
        if (gm.GetRep() >= unlockShopPrice)
        {
            gm.removeRep(unlockShopPrice);

            // reward
            UnlockShopReward();

            //disable button
            DisableButtonViaInteractable(unlockShopButton);
        }
        else
        {
            Debug.Log("Error! Not enough VBUCKS");
            // Maybe play error sound.
        }
    }

    void UnlockShopReward()
    {
        upgradeMovementButton.interactable = true;
        installAutoRepButton.interactable = true;
    }

    void CompleteGameCheckAndResolve()
    {
        if (
            unlockShopButton.interactable == false &&
            upgradeMovementButton.interactable == false &&
            installAutoRepButton.interactable == false
           )
        {
            // Make end game available
            completeGameButton.interactable = true;
        }
    }

    // TO BE WORKED ON...
    //void CheckIfIndicatorNeedToAppearAndResolve()
    //{
    //    // loop through list of enabled buttons.
    //    // check against player rep
    //    // if player rep is above atleast one of them... show indicator.
    //
    //    foreach(var item in upgradeButtons)
    //    {
    //        if (item.enabled)
    //        {
    //
    //        }
    //    }
    //
    //    //if (gm.GetRep() >= )
    //}

    public void UpgradeMovement()
    {
        if (gm.GetRep() >= upgradeMovementPrice)
        {
            gm.removeRep(upgradeMovementPrice);

            // reward
            playerController.moveSpeed = playerController.moveSpeed + 1;

            //disable button
            DisableButtonViaInteractable(upgradeMovementButton);
        }
        else
        {
            Debug.Log("Error! Not enough VBUCKS");
            // Maybe play error sound.
        }
    }
    
    public void _InstallAutoRep()
    {
        if (gm.GetRep() >= installAutoRepPrice)
        {
            gm.removeRep(installAutoRepPrice);

            // reward
            // enable autorep generator.
            autoRepGeneratorObject.SetActive(true);

            //disable button
            DisableButtonViaInteractable(installAutoRepButton);
        }
        else
        {
            Debug.Log("Error! Not enough VBUCKS");
            // Maybe play error sound.
        }
    }

    public void _CompleteGame()
    {
        if (gm.GetRep() >= completeGamePrice)
        {
            gm.removeRep(completeGamePrice);

            // reward
            // send user to end game scene.

            //disable button
            //DisableButtonViaInteractable(installAutoRepButton);
            // Load next scene which should be end scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
        {
            Debug.Log("Error! Not enough VBUCKS");
            // Maybe play error sound.
        }
    }



    public void DisableButtonViaInteractable(Button button)
    {
        button.interactable = false;
    }

}
