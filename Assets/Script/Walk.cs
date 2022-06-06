using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
  public float maxSpeed;
  public float speed = 3F;
  float RunSpeed;
  Rigidbody2D rigid;
  SpriteRenderer spriteRenderer;
  Animator anim;

  void Awake(){
    rigid = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

  void Update(){
    //Stop Speed
    if (Input.GetKey(KeyCode.RightArrow)){
        rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
              spriteRenderer.flipX = false;

    }

    //Direction Sprite
    if(Input.GetKey(KeyCode.LeftArrow))
      spriteRenderer.flipX = true;

      if(Mathf.Abs(rigid.velocity.x) < 0.08)
        anim.SetBool("isWalking", false);
      else
        anim.SetBool("isWalking", true);
  }

  void FixedUpdate(){
    //Move Speed
    float h= Input.GetAxisRaw("Horizontal");
    rigid.AddForce(Vector2.right * h , ForceMode2D.Impulse);
    rigid.velocity = new Vector2(h * maxSpeed , rigid.velocity.y);
    if(Input.GetKey(KeyCode.LeftShift)){
      RunSpeed = speed+maxSpeed;
      anim.SetBool("Run", true);
    }
    else{
      RunSpeed = speed;
      anim.SetBool("Run", false);
    }
    //Max Speed 
    if(rigid.velocity.x > RunSpeed) //Right Max Speed
      rigid.velocity = new Vector2(RunSpeed, rigid.velocity.y);
    else if(rigid.velocity.x < RunSpeed*(-1)) //Left Max Speed
      rigid.velocity = new Vector2(RunSpeed*(-1), rigid.velocity.y);
  }
}