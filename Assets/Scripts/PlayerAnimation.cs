using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Play animations with numpad uncomment anim.Play() to use
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //anim.Play("");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //anim.Play("");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //anim.Play("");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //anim.Play("");
        }


    }
}
