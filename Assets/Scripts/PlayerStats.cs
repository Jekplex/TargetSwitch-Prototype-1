using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Blackthornprod's Health/Heart System.

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Requirements")]
    public ShopMenu shopScript;
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void HurtPlayer()
    {
        //
        health = Mathf.Clamp(health - 1, 0, numOfHearts);
        healthCheck();
    }

    public void KillPlayer()
    {
        health = 0;
        healthCheck();
    }

    public void HealPlayer()
    {
        health = Mathf.Clamp(health + 1, 0, numOfHearts);
    }

    private void healthCheck()
    {
        if (health == 0)
        {
            // End Game

            gm.DoPlayerHasDiedSequence();
            //DoPlayerHasDiedSequence();
        }
    }

    
}
