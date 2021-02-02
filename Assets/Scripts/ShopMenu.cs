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
    }

    void OpenShop()
    {
        Time.timeScale = 0f;
        shopPanel.GetComponent<Image>().enabled = true;
        shopPanel.transform.Find("Shop Items").gameObject.SetActive(true);
        shopPanel.transform.Find("Title").gameObject.SetActive(true);
        playerController.enabled = false;
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

    //public enum PlayerUpgradeType
    //{
    //    shop,
    //    movement,
    //    autorep
    //}
    //
    //public void ShopItem(string text, int price, PlayerUpgradeType upgrade, Button button)
    //{
    //    if (upgrade == PlayerUpgradeType.shop)
    //    {
    //        
    //    }
    //    else if (upgrade == PlayerUpgradeType.movement)
    //    {
    //
    //    }
    //    else if (upgrade == PlayerUpgradeType.autorep)
    //    {
    //
    //    }
    //
    //}
    //
    //public void UnlockShop(int price, Button button)
    //{
    //    if (gm.getRep() >= price)
    //    {
    //        gm.removeRep(price);
    // 
    //        // reward
    //        playerController.moveSpeed = playerController.moveSpeed + 1;
    // 
    //        // disable
    //        //button.interactable = false;
    // 
    //    }
    //    else
    //    {
    //        Debug.Log("Error! Not enough VBUCKS");
    //        // Play error sound.
    //    }
    //}
    //
    //public void UpgradeMovement()
    //{
    //
    //}
    //
    //public void UpgradeAutoRep()
    //{
    //
    //}

    //void SetButtonText()
    //{
    //    foreach (var item in shopItems)
    //    {
    //        //item.gameObject.name = item.name;
    //        //item.gameObject.GetComponentInChildren<TextMeshPro>().text = item.GetButtonText();
    //        item.gameObject.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = item.GetButtonText();
    //        //item.gameObject.GetComponent<Button>().onClick.AddListener()
    //        // I need to manually add the functionality for each button.

    //    }
    //}

    //void InitButtonSetup()
    //{
    //    for (int i = 0; i < shopItems.Length; i++)
    //    {
    //        if (i == 0)
    //        {
    //            shopItems[i].gameObject.SetActive(true);
    //        }
    //        else
    //        {
    //            shopItems[i].gameObject.SetActive(false);
    //        }

    //    }
    //}

    //
    // In game purchases
    //

    //public void ShopUnlock()
    //{
    //    int price = shopItems[0].price;
    //
    //    /*
    //     * if player has the required amount of cash for upgrade then give upgrade and take cash.
    //     * else don't give upgrade and say "transaction failed" with negative sound.
    //     */
    //
    //    // transaction
    //    if (gm.getRep() >= price)
    //    {
    //        gm.removeRep(price);
    //
    //        // reward
    //        shopItems[1].gameObject.SetActive(true); // Enable "Gotta Go Fast" upgrade
    //        shopItems[2].gameObject.SetActive(true); // Enable "RepMiner" upgrade.
    //
    //        // misc
    //        shopItems[0].gameObject.GetComponent<Button>().interactable = false; // Disable this button.
    //
    //        SetButtonText();
    //    }
    //    else
    //    {
    //        Debug.Log("Error! Not enough VBUCKS");
    //    }
    //        
    //    
    //}
    //
    //public void GottaGoFast()
    //{
    //    int price = shopItems[1].price;
    //
    //    /*
    //     * if player has the required amount of cash for upgrade then give upgrade and take cash.
    //     * else don't give upgrade and say "transaction failed" with negative sound.
    //     */
    //
    //    // transaction
    //    if (gm.getRep() > price)
    //    {
    //        gm.removeRep(price);
    //
    //        // reward
    //        playerController.moveSpeed = playerController.moveSpeed * 2;
    //
    //        // misc
    //        shopItems[1].gameObject.GetComponent<Button>().interactable = false; // Disable this button.
    //
    //    }
    //    else
    //    {
    //        Debug.Log("Error! Not enough VBUCKS");
    //    }
    //
    //}


}

