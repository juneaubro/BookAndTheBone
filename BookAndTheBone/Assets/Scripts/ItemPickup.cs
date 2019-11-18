using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject Item;
    public GameObject Player;
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
}
/*
 * void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickUp == true)
        {
            if (collision.gameObject.name == "Dog")
            {
                Item.transform.position = dog.transform.position;
                Item.transform.parent = Player.transform;
            }
        }
    }
*/