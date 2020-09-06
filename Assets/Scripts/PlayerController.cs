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

    public float moveSpeed = 10.0f;
    
    private Rigidbody2D rb;

    private Vector2 WASD_Input;
    private Vector2 Mouse_Input;

    private Camera mainCam;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        WASD_Input = new Vector2(0, 0);        
    }

    private void Update()
    {
        WASD_Input_Calc();

        Mouse_Input_Calc();
    }

    void WASD_Input_Calc()
    {
        WASD_Input = new Vector2(0, 0);

        if (Keyboard.current.wKey.isPressed)
        {
            WASD_Input += Vector2.up;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            WASD_Input += Vector2.left;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            WASD_Input += Vector2.down;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            WASD_Input += Vector2.right;
        }

        //

        if (WASD_Input == new Vector2(0, 0))
        {
            // Do nothing.
        }
        else
        {
            WASD_Input.Normalize();
            //Debug.Log(WASD_Input);

            MovePlayer(WASD_Input);
        }
        
    }
    
    void Mouse_Input_Calc()
    {
        Mouse_Input = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    void MovePlayer(Vector2 input)
    {
        var transformPos = new Vector2(transform.position.x, transform.position.y);

        input *= moveSpeed;
        input *= Time.deltaTime;

        rb.MovePosition(transformPos += input);
    }

    // This code is so clean :D
    // Currently only handles WASD Input.

}
