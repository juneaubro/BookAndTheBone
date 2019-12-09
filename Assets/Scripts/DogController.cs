using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogController : MonoBehaviour
{
    public float runSpeed;
    public GameObject book;
    public bool facingRight;
    public bool reverseGravity;
    public bool inAir;
    public int jumpPower = 1425;
    public float jumpCoolDown = 0.33f;

    private float counter = 0;
    private float dirX;
    private Animator anim;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        reverseGravity = false;
        inAir = false;
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;

        dirX = Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        if (rBody.gravityScale == -12)
        {
            reverseGravity = true;
            jumpPower = -1425;
        } else
        {
            reverseGravity = false;
            jumpPower = 1425;
        }

        Flip(dirX);

        if (Input.GetKeyDown(KeyCode.W) && inAir == false && counter > jumpCoolDown)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
            inAir = true;
            counter = 0;
        }

        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))    // If the dog is moving and not barking.
        {
            anim.SetBool("isRunning", true);
        } else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.E) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("hit");
        }

        if (Input.GetKey(KeyCode.S) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark") && !anim.GetCurrentAnimatorStateInfo(0).IsName("running"))
        {
            anim.SetBool("isSitting", true);
        } else
        {
            anim.SetBool("isSitting", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
        {
            anim.SetBool("isJumping", true);
        } else
        {
            anim.SetBool("isJumping", false);
        }
    }

    void Flip(float dirX)   // To make the dog flip around to face the direction he is going.
    {
        if (dirX > 0 && !facingRight || dirX < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "book")
        {
            Destroy(book);
        }

        if (collision.gameObject.name == "portal2")
        {
            SceneManager.LoadScene("Floor2");
        }

        if (collision.gameObject.name == "portal1")
        {
            SceneManager.LoadScene("Floor3");
        }

        if (collision.gameObject.name == "portal")
        {
            SceneManager.LoadScene("Floor4");
        }

        if (collision.gameObject.tag == "Ground")
        {
            inAir = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spikes2")
        {
            SceneManager.LoadScene("Floor2");
        }

        if (collision.gameObject.tag == "Spikes3")
        {
            SceneManager.LoadScene("Floor3");
        }
    }
}
        

       


