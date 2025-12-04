using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;
    float jumpForce = 5f;

    void Update()
    {
        //move left and right
        //hitbox velocity is new time the horizontal movespeed, in the x value  

    }

public void Move(InputAction.CallbackContext context)
{
    Vector2 input = context.ReadValue<Vector2>();
    horizontalMovement = input.x;
}
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
        Debug.Log("hey");
    }

}
