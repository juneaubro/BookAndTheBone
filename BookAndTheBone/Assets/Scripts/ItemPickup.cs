using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject Item;
    public GameObject Player;
    public GameObject gravityTemp;
    public GameObject zeroGravityTemp;
    public Transform dog;

    private bool pickUp;

    // Start is called before the first frame update
    void Start()
    {
        pickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && pickUp == true)
        {
            Item.transform.position = dog.transform.position;
            Item.transform.parent = Player.transform;
            Item.GetComponent<Rigidbody2D>().gravityScale = gravityTemp.GetComponent<Rigidbody2D>().gravityScale;

        } else
        {
            pickUp = false;
            Item.transform.parent = null;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dog")
        {
            pickUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Item.GetComponent<Rigidbody2D>().gravityScale = zeroGravityTemp.GetComponent<Rigidbody2D>().gravityScale;
            Item.GetComponent<Rigidbody2D>().velocity = zeroGravityTemp.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
