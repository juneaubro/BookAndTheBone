using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        DogController controller = other.GetComponent<DogController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
