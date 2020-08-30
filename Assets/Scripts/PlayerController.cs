using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;


    public void Move(InputAction.CallbackContext context)
    {
        
        var moveDirection = context.ReadValue<Vector2>();

        transform.position += new Vector3(moveDirection.x, moveDirection.y) * moveSpeed * Time.deltaTime;

    }

}
