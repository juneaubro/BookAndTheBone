using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawn : MonoBehaviour
{
    public GameObject bridge;
    public GameObject bridge1;
    public GameObject bridge2;
    public GameObject bridge3;
    public GameObject bridge4;
    public GameObject portal;

    private bool active = false;

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            bridge.SetActive(true);
            bridge1.SetActive(true);
            bridge2.SetActive(true);
            bridge3.SetActive(true);
            bridge4.SetActive(true);
            portal.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IceTrigger")
            active = true;
    }
}