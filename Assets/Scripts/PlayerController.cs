using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // New input system doesn't have continous input on mouse and keyboard.
    // So player is required to spam WASD - which is not what I want.
    // The only way I see to bypass this issue is by hand coding
    // all inputs through this script.

    //public InputActionReference myTest;

    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        //Vector2 targetPos;

        if (Keyboard.current.wKey.isPressed)
        {
            // Move player up
            //targetPos = temp + (Vector2.up * moveSpeed);
            //rb.MovePosition(targetPos + (Vector2.up * moveSpeed) * Time.deltaTime);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            // Move player left
            //targetPos += new Vector2(-1, 0);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            // Move player down
            //targetPos += new Vector2(0, -1);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            // Move player right
            //targetPos += new Vector2(1, 0);

        }

        //targetPos.Normalize();
        //rb.MovePosition(targetPos);

        //Debug.Log(targetMovePos);

    }

    //public void Move(InputAction.CallbackContext context)
    //{
    //    // Keyboard and mouse.
    //
    //    var targetPos = new Vector2(transform.position.x, transform.position.y);
    //    var moveVector = context.ReadValue<Vector2>();
    //
    //    targetPos += (moveVector * moveSpeed) * Time.deltaTime;
    //
    //    rb.MovePosition(targetPos);
    //
    //    //Move(context);
    //
    // 
    //    //Debug.Log(moveVector);
    //
    //}

}
