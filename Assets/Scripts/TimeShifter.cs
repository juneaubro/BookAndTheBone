using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShifter : MonoBehaviour
{
    // Public Variables
    public GameObject ice;
    public Transform IceSpawn;
    public float fireRate = 0.5f;
    public float speed = 10f;
    public GameObject tempObject;

    // Private variables
    private float counter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        counter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.M) && counter > fireRate)
        {
            // Instantiate the laser
            Instantiate(ice, IceSpawn.position, ice.transform.rotation);
            counter = 0.0f;
        }
    }

    // Update is called once per frame
    // FixedUpdate is used when modifying physics values
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
    }
}

