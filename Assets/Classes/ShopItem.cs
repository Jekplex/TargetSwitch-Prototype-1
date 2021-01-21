using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{

    public string name;
    public int price;
    public GameObject gameObject;

    [SerializeField] private string buttonText;

    public ShopItem()
    {
        UpdateButtonText();
    }

    public string GetButtonText()
    {
        UpdateButtonText();
        return buttonText;
    }

    public void UpdateButtonText()
    {
        buttonText = $"{this.name} | {this.price}r";
    }

}
