using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    public GameMaster gm;
    public PlayerController playerController;

    [Header("Unlock Shop")]
    public Button UnlockShopButton;
    public int UnlockShopPrice;

    private void Start()
    {
        //
    }


    public void UnlockShopFunction()
    {
        if (gm.GetRep() >= UnlockShopPrice)
        {
            gm.removeRep(UnlockShopPrice);
     
            // reward
            playerController.moveSpeed = playerController.moveSpeed + 1;

            //disable
            UnlockShopButton.interactable = false;
        }
        else
        {
            Debug.Log("Error! Not enough VBUCKS");
            // Maybe play error sound.
        }
    }

    //public void UpgradeMovement()
    //{
    //
    //}
    //
    //public void InstallAutoRep()
    //{
    //
    //}
    //
    //public void DisableButton(Button button)
    //{
    //    button.interactable = false;
    //}

}
