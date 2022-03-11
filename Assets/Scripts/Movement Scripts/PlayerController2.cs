using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove =0f;
    bool jump = false;
    bool crouch = false;
    private Rigidbody2D rb;
    float vely;
   

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("_Velocidad en X: "+ horizontalMove );
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        // && rb.velocity.y == 0f 
        
        if( Input.GetButtonDown("Jump") ){

            jump = true;
            animator.SetBool("IsJumping",true);
        }
        
        if (Input.GetButtonDown("Crouch")  )
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }
     

    // private bool IsGrounded(){
        
    // }
    public void OnLanding (){
        animator.SetBool("IsJumping",false);
    }

    public void OnCrouching (bool isCrouching){
        animator.SetBool("IsCrouching",isCrouching);
    }
    

     void FixedUpdate() {
        rb = GetComponent<Rigidbody2D>();
        Vector3 vel = rb.velocity;
        vely = vel.y;
        Debug.Log("_Velocidad en Y2: "+ vel.y );


        // Move Character
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;

    }
    
}   

