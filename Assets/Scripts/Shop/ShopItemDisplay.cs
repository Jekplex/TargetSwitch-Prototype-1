using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShopItemDisplay : MonoBehaviour
{
    public ShopItem item;

    private TextMeshProUGUI textContainer;
    private Button thisButton;

    private GameMaster gm;

    //private RightClickIndicator rc_indicator;

    

    // Start is called before the first frame update
    void Start()
    {
        textContainer = GetComponentInChildren<TextMeshProUGUI>();
        thisButton = GetComponent<Button>();
        //rc_indicator = GameObject.FindGameObjectWithTag("rc_indicator").GetComponent<RightClickIndicator>();

        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        textContainer.text = $"{item.name} | {item.price}Rep";

        thisButton.onClick.AddListener(() => Transaction(item));
    }

    void Transaction(ShopItem item)
    {
        if (gm.GetRep() > item.price)
        {
            gm.removeRep(item.price);

            GiveRewardDependingOnItemsFunction();
        }

        void GiveRewardDependingOnItemsFunction()
        {
            switch (item.Function)
            {
                case ShopItem.Functions.UnlockShop:
                    UnlockShop();
                    break;

                case ShopItem.Functions.IncreaseMovementSpeed:
                    IncreaseMovementSpeed();
                    break;

                case ShopItem.Functions.InstallAutoRep:
                    InstallAutoRep();
                    break;

                case ShopItem.Functions.WinGame:
                    WinGame();
                    break;

                default:
                    Debug.Log("Error!");
                    break;
            }

            thisButton.interactable = false;

            void UnlockShop()
            {
                var listOfButtons = thisButton.gameObject.transform.parent.GetComponentsInChildren<Button>();
                foreach (var button in listOfButtons)
                {
                    button.interactable = true;
                }
                
            }

            void IncreaseMovementSpeed()
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveSpeed += 1;
            }

            void InstallAutoRep()
            {
                GameObject.Find("Auto Rep Miner").SetActive(true);
            }

            void WinGame()
            {
                // load next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
