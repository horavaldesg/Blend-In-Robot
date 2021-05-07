using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateButton : MonoBehaviour
{

    public GameObject highlight1;
    public GameObject highlight2;
    public GameObject highlight3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            highlight1.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            highlight2.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            highlight3.SetActive(true);
        }
        else
        {
            highlight1.SetActive(false);
            highlight2.SetActive(false);
            highlight3.SetActive(false);
        }
    }
}
