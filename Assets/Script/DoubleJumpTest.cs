using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpTest : MonoBehaviour
{
  [SerializeField] float jumpForce = 600f, speed = 5f;
  float moveX;
  Rigidbody2D rb;
  
  bool doubleJumpState = false;
  bool isGround = false;
  Animator anim;


  void Start(){
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
  }

  void Update(){
    if (rb.velocity.y == 0)
      isGround = true;
    else
      isGround = false;

    if(isGround)
      doubleJumpState = true;

    if(isGround && Input.GetButtonDown("Jump")){
      JumpAddForce();
    }
    else if(doubleJumpState && Input.GetButtonDown("Jump"))
    {
      JumpAddForce();
      anim.SetBool("DoubleJump", true);
      doubleJumpState = false;
    }

    moveX = Input.GetAxis("Horizontal")*speed;
    rb.velocity = new Vector2(moveX, rb.velocity.y);


  }


  void FixedUpdate(){
    //Landing Platform
    if(rb.velocity.y <0){
      // Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
      RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 3, LayerMask.GetMask("platform"));
      if(rayHit.collider != null){
        // if(rayHit.distance < 0.4f){
          //Debug.Log(rayHit.collider.name);
            anim.SetBool("isJumping", false);
            anim.SetBool("DoubleJump", false);
        // }
      }
    }
    
  
  }
  
  void JumpAddForce()
  {
    anim.SetBool("isJumping", true);
    rb.velocity = new Vector2(rb.velocity.x, 0f);
    rb.AddForce(Vector2.up*jumpForce);
  }
}