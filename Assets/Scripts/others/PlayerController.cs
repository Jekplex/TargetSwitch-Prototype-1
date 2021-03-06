﻿using System.Collections;
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

    public GameObject bulletPrefab;

    public float bulletCooldown = 0.5f;
    private float _bulletCooldown;
    private bool isBulletCooldownOn = false;

    public float fireKnockbackStrength = 0.01f;

    //
    private Vector2 playerToNorthVector;
    private Vector2 playerToMouseVector;

    private Vector2 LeftClickPlayerPos;

    public CameraShake camShake;

    public Camera cam2;

    // May need a public bool called controls to enable/disable controls in menus or when mouse is off the game.

    private void Start()
    {
        AimIndicatorObj = transform.GetChild(0).gameObject; // GameObject
        AimIndicatorSprite = AimIndicatorObj.transform.GetChild(0); // Transform

        rb = GetComponent<Rigidbody2D>();
        
        WASD_Input = new Vector2(0, 0);

        _bulletCooldown = bulletCooldown;
    }

    private void Update()
    {
        WASD_Input_Calc();
        // Worried that the above might need to go into FixedUpdate...

        MousePos_Input_Calc();

        MouseButton_Input_Calc();

        if (isBulletCooldownOn)
        {
            _bulletCooldown -= Time.deltaTime;

            if (_bulletCooldown <= 0)
            {
                isBulletCooldownOn = false;      
            }
        }
    }

    void WASD_Input_Calc()
    {
        rb.velocity = Vector2.zero;
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
            MovePlayer(WASD_Input);
        }
        else
        {
            WASD_Input.Normalize();
            //Debug.Log(WASD_Input);

            MovePlayer(WASD_Input);

            Set_AimIndicator();
        }
        

    }
    
    void MousePos_Input_Calc()
    {
        Mouse_Input = cam2.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Set_AimIndicator();
    }

    void MouseButton_Input_Calc()
    {
        
        if (Mouse.current.leftButton.isPressed) 
        {
            // Shoot

            // 
            if (!isBulletCooldownOn)
            {
                LeftClickPlayerPos = transform.position;
                Instantiate(bulletPrefab, AimIndicatorSprite.position, AimIndicatorSprite.rotation);

                //rb.velocity = Vector2.zero;

                //knockback
                //rb.AddForce((Vector2.zero - (Mouse_Input * 2)) * fireKnockbackStrength, ForceMode2D.Impulse);
                //var temp = (Vector2)transform.position - Mouse_Input;
                //transform.position = Vector2.ClampMagnitude(temp, 1f) * fireKnockbackStrength;
                    //(Vector2)transform.position - (Vector2.ClampMagnitude(Mouse_Input, 1f));

                

                //cam shake?
                //camShake.ShakeCamera(1, 0.1f);

                isBulletCooldownOn = true;
                _bulletCooldown = bulletCooldown;
            }

        }

        //if (Mouse.current.rightButton.isPressed)
        //{
        //    // Pause or Special Heavy Attack (Something like rockets)
        //
        //}

    }

    public Vector2 GetLeftClickPlayerPos()
    {
        return LeftClickPlayerPos;
    }

    void Set_AimIndicator()
    {
        playerToNorthVector = new Vector2(transform.position.x, transform.position.y + 100);

        // PM = M - P
        // ^ This means PlayerToMouse (Vector) = MousePos - PlayerPos
        playerToMouseVector = new Vector2(Mouse_Input.x - transform.position.x, Mouse_Input.y - transform.position.y);

        var angle = Vector2.SignedAngle(playerToNorthVector, playerToMouseVector);
        AimIndicatorObj.transform.localRotation = Quaternion.Euler(0, 0, 135 + angle);

        // Having conflicts to use var or not...
        // Is it more efficient to just declare it as a float as I know the output...
        // Instead of letting the computer figure it out on compilation??

        // These are the real questions I think about.
    }

    void MovePlayer(Vector2 input)
    {
        //var transformPos = new Vector2(transform.position.x, transform.position.y);
        //
        //input *= moveSpeed;
        //input *= Time.deltaTime;
        //
        //rb.MovePosition(transformPos += input);

        input = input * moveSpeed;
        //input = input * moveSpeed * Time.deltaTime;
        rb.velocity = input;
        //
    }

    // This code is so clean :D
    // Currently only handles WASD Input.

}
