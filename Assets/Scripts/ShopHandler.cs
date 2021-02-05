using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        unlockShopButton.interactable = true;
        upgradeMovementButton.interactable = false;
        installAutoRepButton.interactable = false;
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
            Debug.Log("This hasn't been implemented yet...");

            //disable button
            DisableButtonViaInteractable(installAutoRepButton);
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
