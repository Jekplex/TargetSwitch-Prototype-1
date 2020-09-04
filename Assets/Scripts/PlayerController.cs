using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Keyboard and Mouse ONLY

    private void Update()
    {

        playerMove();

    }

    void playerMove()
    {
        // W A S D

        if (Keyboard.current.wKey.ReadValue() > 0.0f)
        {
            // Move player up
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.ReadValue() > 0.0f)
        {
            // Move player left
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.ReadValue() > 0.0f)
        {
            // Move player down
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.ReadValue() > 0.0f) 
        {
            // Move player right
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
