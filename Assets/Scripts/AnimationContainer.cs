using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContainer : MonoBehaviour
{
    public static string currentAnim;
    GameObject[] robots;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

        robots = GameObject.FindGameObjectsWithTag("Robot");
    }

    // Update is called once per frame
    void Update()
    {
        if (robots != null)
        {
            robots = GameObject.FindGameObjectsWithTag("Robot");
            //Debug.Log(robots.Length -2);
            foreach (GameObject robot in robots)
            {
                if (robot != null)
                {
                    string clipInfo = robot.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
                    //Debug.Log(robot.name + i++ + " " + clipInfo);
                    currentAnim = clipInfo;
                }

                BehaviourScript.state = Random.Range(0, 3);
               
            }
        }

    }
}
