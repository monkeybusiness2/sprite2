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


    [SerializeField] private bool isGroundedBool;
    private bool canJump; 
    

    //movement variables
    void Update()
    {
        isGroundedBool = IsGrounded();
        {
            canJump = true;
            Debug.Log("we are grounded");
        }
        
         moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
        
    }
    

    public void Move(InputAction.CallbackContext context)  
    {
         
        moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump) //if button is pressed and is able to jump 
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            canJump = false;
        }
        
        /*{
            canJump = false;
            
        }*/
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);//velocity is euqal to horitzontal move * movespeed. and rb.velcoty does y stays or doesnt lock
    }

     private bool IsGrounded()
    {
        float rayLength = 0.25f; //sets the ray of the length below the player hitbox
        Vector2 rayOrigin = new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y - 0.1f);  //sets a raycast orgin right below the character
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, groundLayer);
        return hit.collider != null;

    
    }
}
