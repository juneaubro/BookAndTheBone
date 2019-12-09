using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject tempIce;

    private BridgeSpawn bridgeScript;
    private PortalSpawn portalScript;
    public GameObject Dog;
    private Rigidbody2D rBody;
    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        bridgeScript = GetComponent<BridgeSpawn>();
        portalScript = GetComponent<PortalSpawn>();

        if(Dog.GetComponent<Rigidbody2D>().transform.localScale.x == -1) // shoots right when facing right, and shooting left when facing left.
        rBody.velocity = Vector2.right * speed;
        else
        rBody.velocity = Vector2.left * speed;
    }

    private void FixedUpdate()
    {
        counter += Time.deltaTime;

        if (this.gameObject.name == "beams(Clone)" && counter > 1)
            Destroy(this.gameObject);
    }
}
