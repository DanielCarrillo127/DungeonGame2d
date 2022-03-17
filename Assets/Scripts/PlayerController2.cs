using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]Transform SpawnPlayer;
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove =0f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
     void Start()
     {
        transform.position = SpawnPlayer.position;
     }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));


        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }

    }
    public void OnLanding (){
        animator.SetBool("IsJumping",false);
    }

    public void OnCrouching (bool isCrouching){
        animator.SetBool("IsCrouching",isCrouching);
    }
    

     void FixedUpdate() {
        // Move Character
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
    
}   

