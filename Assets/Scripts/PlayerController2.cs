using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField]Transform SpawnPlayer;
    private GameObject currentOneWayPlatform;
    [SerializeField] private CapsuleCollider2D playerCollider;
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
        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
                Debug.Log("down");
            }
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("OneWayPlatform")){
            currentOneWayPlatform = collision.gameObject;
            
        }
         
    }
    
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("OneWayPlatform")){
            currentOneWayPlatform = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("diamondScore"))
        {
            Destroy(other.gameObject);
        }
         
    }

    private IEnumerator DisableCollision(){
    BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
    Physics2D.IgnoreCollision(playerCollider,platformCollider);
    yield return new WaitForSeconds(0.25f);
    Physics2D.IgnoreCollision(playerCollider,platformCollider,false);
    }      
} 

