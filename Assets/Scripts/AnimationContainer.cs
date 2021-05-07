using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContainer : MonoBehaviour
{
    public static string currentAnim;
    GameObject[] robots;
    float i = 0;
    [SerializeField] int rate = 5;
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
            i += Time.deltaTime;
            //Debug.Log(i);
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
                if (i > rate)
                {
                    BehaviourScript.state = Random.Range(1, 6);
                    //Debug.Log(BehaviourScript.state);
                    i = 0;
                }
                if(BehaviourScript.state == 2 || BehaviourScript.state == 5)
                {
                    GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
                    foreach(GameObject spawner in spawners)
                    {
                        spawner.GetComponent<RobotSpawner>().enabled = false;
                    }
                }
                else
                {
                    GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
                    foreach (GameObject spawner in spawners)
                    {
                        spawner.GetComponent<RobotSpawner>().enabled = true;
                    }
                }
               
            }
        }

    }
}
