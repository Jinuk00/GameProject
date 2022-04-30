using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
  [SerializeField] float jumpForce = 600f, speed = 5f;
  float moveX;
  Rigidbody2D rb;
  
  bool doubleJumpState = false;
  bool isGround = false;

  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }

  void Update(){
    MoveMent();
  }

  void MoveMent(){
    if (rb.velocity.y == 0)
      isGround = true;
    else
      isGround = false;

    if(isGround)
      doubleJumpState = true;

    if(isGround && Input.GetButtonDown("Jump"))
      JumpAddForce();
    else if(doubleJumpState && Input.GetButtonDown("Jump"))
    {
      JumpAddForce();
      doubleJumpState = false;
    }

    moveX = Input.GetAxis("Horizontal")*speed;
    rb.velocity = new Vector2(moveX, rb.velocity.y);
  }

  void JumpAddForce()
  {
    rb.velocity = new Vector2(rb.velocity.x, 0f);
    rb.AddForce(Vector2.up*jumpForce);
  }
}