using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesOutOfRange : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8) // 8 - enemy layer {
        {
            Destroy(collision.gameObject);
        }
        
    }

}
