﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public enum EnemyType
    {
        Square,
        Triangle,
        Circle
    }

    public EnemyType myEnemyType;

    // I want the enemy to move towards the player.
    
    // I want the enemy to be killed when a player's bullets hit it.

    // I want the player to gain rep if target is inline with object
    // else lose rep.

    public float moveSpeed = 3f;

    private Rigidbody2D rb;

    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        // Calculates enemy movement. // They fall towards the bottom of the screen.
        rb.MovePosition((Vector2)transform.position + Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
