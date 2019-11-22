using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject canvas;

    private bool helpOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //  Toggle help menu
        if (Input.GetKeyDown(KeyCode.H))
        {
            helpOn = !helpOn;
            canvas.SetActive(helpOn);
            
        }
    }
}
