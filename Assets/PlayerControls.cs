using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    private float coyoteTime = .02f; 
    private float coyoteTimeCounter;

   
    

    //movement variables
    void Update()
    {
        
         moveX = Input.GetAxis("Horizontal");//movex is the horitzontal x axis

        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
             Debug.Log("this is the timer" + coyoteTimeCounter);
            
            
            
        }
         else 
        {
            coyoteTimeCounter -= Time.deltaTime;
            Debug.Log("this is the timer" + coyoteTimeCounter);
        }
        
       

        
    }
    

    public void Move(InputAction.CallbackContext context )  
    {
         
        moveX = Input.GetAxis("Horizontal"); //movex is the horitzontal x axis
    }
    public void Jump(InputAction.CallbackContext context)
    {
       if (context.performed && coyoteTimeCounter > 0)
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
        }
    }

    private void OnCollisionExit2D(Collision2D other) //check for other ocllision obejcts
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    
}
