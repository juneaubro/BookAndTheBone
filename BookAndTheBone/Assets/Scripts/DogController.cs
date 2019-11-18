﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public float runSpeed;
    public int jumpPower;
    public float jumpCooldown;
    public GameObject Book_Key;

    private float dirX;
    private Animator anim;
    private Collision2D hit;
    private bool facingRight;
    
    private float counter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        dirX = Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        Flip(dirX);

        if(Input.GetKeyDown(KeyCode.W) && counter > jumpCooldown)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            counter = 0f;
        }

        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))    // If the dog is moving and not barking.
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.E) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("hit");
        }

        if(Input.GetKey(KeyCode.S) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
        {
            anim.SetBool("isSitting", true);
        } else if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isSitting", false);
        }

        if (Input.GetKey(KeyCode.W) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
        {
            anim.SetBool("isJumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("isJumping", false);
        }
    }

    private void Flip(float dirX)   // To make the dog flip around to face the direction he is going.
    {
        if (dirX > 0 && !facingRight || dirX < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
