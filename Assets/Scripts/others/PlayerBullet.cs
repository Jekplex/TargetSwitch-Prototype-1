using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float timeUntilDeath = 3f;

    private float timer;

    private Rigidbody2D rb;

    private void Start()
    {
        timer = 0.0f;

        rb = GetComponent<Rigidbody2D>();
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
            // else keep moving
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.Self);
            //rb.MovePosition((Vector2)transform.position + Vector2.right * bulletSpeed * Time.deltaTime);
        }

    }

}
