using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    // The name of the button is taken from the name of the scriptable object.
    // Therefore, no need for string name.

    public int price;

    public enum Functions
    {
        UnlockShop,
        IncreaseMovementSpeed,
        InstallAutoRep,
        WinGame
    }

    public Functions Function;
}
