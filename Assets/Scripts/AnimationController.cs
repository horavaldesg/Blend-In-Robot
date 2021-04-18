using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    GameObject[] robots;
    Animation robotAnim;
    public bool walk;
    public bool still;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        robots = GameObject.FindGameObjectsWithTag("Robot");
       

        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;

        }

    }

    
    
    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            Walk();
        }
        else if (still)
        {
            Still();
        }
        else
        {
            Still();
        }
    }

    void Walk()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].GetComponent<Animator>().Play("RobotWalk");

        }
    }
    void Still()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].GetComponent<Animator>().Play("Still");


        }
    }
}
