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
        //Kung Fu
        if (Input.GetKey(KeyCode.Alpha1))
        {
            anim.Play("kungFu");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            anim.Play("Still");
        }
        //Surrender
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            anim.Play("Surrender");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            anim.Play("Still");
        }
        //The Robot
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            anim.Play("theRobot");
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            anim.Play("Still");
        }



    }
}
