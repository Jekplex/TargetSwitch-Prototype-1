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

    private GameObject AimIndicatorObj;
    private Transform AimIndicatorSprite;
    
    private Rigidbody2D rb;

    private Vector2 WASD_Input;
    [SerializeField] private Vector2 Mouse_Input;

    private void Start()
    {
        AimIndicatorObj = transform.GetChild(0).gameObject; // GameObject
        AimIndicatorSprite = AimIndicatorObj.transform.GetChild(0); // Transform

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

            Set_AimIndicator();
        }
        

    }
    
    void Mouse_Input_Calc()
    {
        Mouse_Input = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Set_AimIndicator();
    }

    void Set_AimIndicator()
    {
        //Vector2 temp = new Vector2(0.4242641f, -0.4242641f);
        //Vector2 temp = new Vector2(transform.position.x, transform.position.y + 10);

        //var angle = Vector2.SignedAngle(Mouse_Input, temp);
        //var angle = Vector2.SignedAngle(Mouse_Input, gameObject.transform.position);
        
        //AimIndicatorObj.transform.rotation = Quaternion.Euler(0, 0, -angle +90  /*+90*/);

        // Having conflicts to use var or not...
        // Is it more efficient to just declare it as a float as I know the output...
        // Instead of letting the computer figure it out on compilation??
        
        // These are the real questions I think about.
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
