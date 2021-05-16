using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRico : MonoBehaviour
{
    public LayerMask collisionMask;

    private float speed = 15;

    private void Update()
    {
        Ray2D ray = new Ray2D(transform.position, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, collisionMask);

        if (hit)
        {
            Vector2 reflectDir = Vector2.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, rot);
        }
    }
}
