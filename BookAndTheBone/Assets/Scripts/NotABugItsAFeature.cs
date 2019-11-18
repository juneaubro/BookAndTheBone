using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotABugItsAFeature : MonoBehaviour
{
    public GameObject Item1;
    public GameObject Item2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Item1.transform.localScale = Item2.transform.localScale;
    }
}
