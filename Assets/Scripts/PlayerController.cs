using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public InputAction myInputActions;

    public float moveSpeed = 1f;
    
    private Rigidbody2D rb;
    private bool playerIsMoving;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
    
        var targetPos = new Vector2(transform.position.x, transform.position.y);
        var moveVector = context.ReadValue<Vector2>();
    
        targetPos += (moveVector * moveSpeed) * Time.deltaTime;
    
        rb.MovePosition(targetPos);
     
        Debug.Log(moveVector);
    
    }

}
