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
    private bool grounded; 
    

    //movement variables
    void Update()
    {
        
         moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
        
    }
    

    public void Move(InputAction.CallbackContext context)  
    {
         
        moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
    }
    public void Jump(InputAction.CallbackContext context && grounded)
    {
       
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);//velocity is euqal to horitzontal move * movespeed. and rb.velcoty does y stays or doesnt lock
    }

    private void OnCollisionEnter2D(Collision2D other) //check for other ocllision obejcts
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGroundedBool = true;
            Debug.Log("We are Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D other) //check for other ocllision obejcts
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGroundedBool = false;
            Debug.Log("Not grounded");
        }
    }

}
