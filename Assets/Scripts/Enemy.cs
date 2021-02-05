using System.Collections;
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
    // else lose rep or nothing

    private float moveSpeed;

    private Rigidbody2D rb;

    private GameObject player;
    private PlayerController playerController;
    private PlayerStats playerStats;

    private GameObject myGameMaster;
    private GameMaster gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerStats = player.GetComponent<PlayerStats>();

        myGameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        gm = myGameMaster.GetComponent<GameMaster>();

        moveSpeed = gm.GetEnemySpeed();
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

            float dist = Vector2.Distance(playerController.GetLeftClickPlayerPos(), gameObject.transform.position);
            gm.EnemyKilled_AddOrRemoveRep(dist, myEnemyType.ToString());

            //Debug.Log("Player has killed : " + myEnemyType.ToString());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerStats.HurtPlayer();
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            // maybe send an knockback to the player?

            // Maybe make the player invinable
            
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }



}
