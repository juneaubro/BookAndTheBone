using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private DogController Dog;
    private bool top;
    
    void Start()
    {
        Dog = GetComponent<DogController>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.gravityScale *= -1;
            Rotation();
        }

    }

    void Rotation()
    {
        if (top == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
       Dog.facingRight = !Dog.facingRight; //* was supposed to have the dog facing the right way when gravity is reversed but i can't get it to work rip
        top = !top;
    }
}
