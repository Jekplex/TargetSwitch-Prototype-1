using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float timeUntilDeath = 3f;

    private float timer;

    private Transform player;
    private Vector2 playerPosAtStart;

    private Rigidbody2D rb;

    private void Start()
    {
        timer = 0.0f;

        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerPosAtStart = player.position;

        SetTrajectoryOfThis();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeUntilDeath)
        {
            // Destroy Object
            Destroy(gameObject);
        }
        else
        {
            Move();
        }

    }

    void SetTrajectoryOfThis()
    {
        var angle = Vector2.SignedAngle(((Vector2)transform.position + Vector2.right) - (Vector2)transform.position, (playerPosAtStart) - (Vector2)transform.position);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Move()
    {
        transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.Self);
        //rb.MovePosition((Vector2)transform.position + Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.gameObject.GetComponent<PlayerStats>().HurtPlayer();
            Destroy(gameObject);
        }
    }
}
