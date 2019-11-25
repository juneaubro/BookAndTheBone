using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    public GameObject portal;
    public GameObject portalTrigger;

    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // Make portal spawn after the book is picked up.
        if (active == true)
        {
            portal.SetActive(true);
            Destroy(portalTrigger);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dog")
        {
            active = true;
        }
    }
}
