using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;
    float jumpForce = 5f;
    public LayerMask groundLayer;
    private float moveX;
    public Transform groundCheck;
    public bool grounded; 
    

    //movement variables
    void Update()
    {
        
         moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
        
    }
    

    public void Move(InputAction.CallbackContext context )  
    {
         
        moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
    }
    public void Jump(InputAction.CallbackContext context)
    {
       if (context.performed && grounded)
        {
               rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);//velocity is euqal to horitzontal move * movespeed. and rb.velcoty does y stays or doesnt lock
    }

    private void OnCollisionEnter2D(Collision2D other) //check for other ocllision obejcts
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            Debug.Log("We are Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D other) //check for other ocllision obejcts
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            Debug.Log("Not grounded");
        }
    }

}
