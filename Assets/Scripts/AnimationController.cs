using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AnimationController : MonoBehaviour
{
    Animator anim;
    public static GameObject[] robots;
    public static Animator currentAnim;
    public bool walk;
    public bool still;
    public bool animCheck;
    public static AnimatorClipInfo[] clipInfo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


        robots = GameObject.FindGameObjectsWithTag("Robot");
        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;
            
            //Every robot position
            //Debug.Log(robots[i].transform.position);

        }


    }

    
    
    // Update is called once per frame
    void Update()
    {
       /*
        foreach (GameObject robot in robots)
        {
            clipInfo =robot.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            robot.GetComponent<Animator>().runtimeAnimatorController = anim.runtimeAnimatorController;
        }
       */
        if (walk)
        {
            Walk();

        }
        else if (still)
        {
            Still();
        }
        else if (animCheck)
        {
            AnimCheck();
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
            robots[i].GetComponent<NavMeshAgent>().speed = 1;
        }
       
    }
    void Still()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            robots[i].GetComponent<Animator>().Play("Still");
            robots[i].GetComponent<NavMeshAgent>().speed = 0;


        }
    }
    void AnimCheck()
    {
        //Robot randomizer
        //int r = Random.Range(0, robots.Length);

        for (int i = 0; i < robots.Length; i++)
        {
            
            clipInfo = robots[i].GetComponent<Animator>().GetCurrentAnimatorClipInfo(i);
            robots[i].GetComponent<Animator>().Play("RobotWalk");
            robots[i].GetComponent<NavMeshAgent>().speed = 1;
            //One random robot
            //robots[r].GetComponent<Animator>().Play(" ");

        }
        
    }
    

}
