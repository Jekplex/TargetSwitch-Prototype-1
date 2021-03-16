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

    public GameObject particleSystem_Death_Square;
    public GameObject particleSystem_Death_Triangle;
    public GameObject particleSystem_Death_Circle;

    public GameObject circleChild1;
    public GameObject circleChild2;

    public GameObject triangleBulletPrefab;

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

    [SerializeField] private float triangleTimeBetweenShots = 1f;
    private float triangleTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerStats = player.GetComponent<PlayerStats>();

        myGameMaster = GameObject.FindGameObjectWithTag("GameMaster");
        gm = myGameMaster.GetComponent<GameMaster>();

        moveSpeed = gm.GetEnemySpeed();

        // triangle stuff
        triangleTimer = triangleTimeBetweenShots;

    }

    private void Update()
    {
        // triangle stuff
        if (myEnemyType == EnemyType.Triangle)
        {
            triangleTimer -= Time.deltaTime;

            if (triangleTimer <= 0f)
            {
                // ShootAtPlayer
                triangle_ShootAtPlayer();
                // ResetTimer
                triangle_ResetTimer();
            }
        }
    }

    void triangle_ShootAtPlayer()
    {
        Instantiate(triangleBulletPrefab, transform.position, transform.rotation);
    }

    void triangle_ResetTimer()
    {
        triangleTimer = triangleTimeBetweenShots;
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

            DoDeathExplosion();

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

    void DoDeathExplosion()
    {
        if (myEnemyType == EnemyType.Square)
        {
            Instantiate(particleSystem_Death_Square, transform.position, Quaternion.identity);
            particleSystem_Death_Square.GetComponent<ParticleSystem>().Play();
        }
        else if (myEnemyType == EnemyType.Triangle)
        {
            Instantiate(particleSystem_Death_Triangle, transform.position, Quaternion.identity);
            particleSystem_Death_Triangle.GetComponent<ParticleSystem>().Play();
        }
        else if (myEnemyType == EnemyType.Circle)
        {
            Instantiate(particleSystem_Death_Circle, transform.position, Quaternion.identity);
            particleSystem_Death_Circle.GetComponent<ParticleSystem>().Play();

            // Coin toss to spawn childs
            var randomNumberToDetermineIfPlayerGetHealed = Random.Range(0f, 1f);
            if (randomNumberToDetermineIfPlayerGetHealed > 0.5f)
            {
                Instantiate(circleChild1, (Vector2)transform.position + new Vector2(0.2f, 0), Quaternion.identity);
                //Instantiate(circleChild2, (Vector2)transform.position + new Vector2(-0.2f, 0), Quaternion.identity);
            }
            
        }
            
    }



}
