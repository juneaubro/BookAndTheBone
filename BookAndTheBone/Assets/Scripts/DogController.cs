using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    private float dirX;
    private float runSpeed = 10f;
    private Animator anim;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        Flip(dirX);

        if(dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("bark"))
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
    }

    private void Flip(float dirX)
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
