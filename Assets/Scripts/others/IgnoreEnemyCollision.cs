using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemyCollision : MonoBehaviour
{
    public bool destroyPlayerBulletOnCollision = false;
    //public bool reboundBullets = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // For whatever reason I cant get objects on different layers to NOT collide with each other.
        // It's annoying.
        // This is what i have to do instead... GRR

        //if (collision.gameObject.layer == 8) // 8 - Enemy Layer
        //{
        //    Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //    return;
        //}

        if (destroyPlayerBulletOnCollision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(collision.gameObject);
            }
        }

    }
}
