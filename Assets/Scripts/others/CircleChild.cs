﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleChild : MonoBehaviour
{
    private AudioSource playerHealSoundSource;

    private Transform player;
    private Rigidbody2D rb2d;
    private PlayerStats playerStats;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.GetComponent<PlayerStats>();
        playerHealSoundSource = GameObject.Find("Player Healed Sound").GetComponent<AudioSource>();
        
    }

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, 0.5f * Time.deltaTime);
        // this needs to be scaled with scalar.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);

            playerStats.HealPlayer();
            playerHealSoundSource.Play();

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerStats.HealPlayer();
            playerHealSoundSource.Play();
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            // maybe send an knockback to the player?

            // Maybe make the player invinable for a while.

        }
    }

}
