using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    GameObject[] lights;
    [SerializeField] GameObject[] stopLights;
    int lightLength = 0;
    [SerializeField]int rate;
    public static bool trigger;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
        lights = GameObject.FindGameObjectsWithTag("StopLight");
        foreach(GameObject light in stopLights)
        {
            light.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger) { 
        i += Time.deltaTime;
        //Debug.Log(i);
        if(i > rate && i < rate + rate)
        {
            stopLights[0].SetActive(true);
            stopLights[1].SetActive(false);
            
        }
        else if(i > rate + rate && i < rate + rate + rate)
        {
            stopLights[0].SetActive(false);
            stopLights[1].SetActive(true);
            i = 0;
        }
        
        if (lights != null)
        {
           
            lights = GameObject.FindGameObjectsWithTag("StopLight");
                foreach (GameObject light in lights)
                {
                    Color lightColor = light.GetComponent<Light>().color;
                    if (lightColor == Color.red)
                    {
                        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        if(robots != null)
                        {
                            foreach(GameObject robot in robots)
                            {
                                if(robot != null)
                                {
                                    string robotClipName = robot.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
                                    string playerClipName = player.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
                                    GameObject claw = GameObject.FindGameObjectWithTag("Claw");
                                    if (robotClipName != playerClipName)
                                    {
                                        ClawAnimation.ClawPlayer(claw, player);
                                    }
                                }
                            }
                        }
                        BehaviourScript.state = 2;
                    }
                    else if (lightColor == Color.green)
                    {
                        BehaviourScript.state = 1;
                        GameObject[] robots = GameObject.FindGameObjectsWithTag("Robot");
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        if (robots != null)
                        {
                            foreach (GameObject robot in robots)
                            {
                                if (robot != null)
                                {
                                    string robotClipName = robot.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
                                    string playerClipName = player.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name;
                                    GameObject claw = GameObject.FindGameObjectWithTag("Claw");
                                    if (robotClipName != playerClipName)
                                    {
                                        ClawAnimation.ClawPlayer(claw, player);
                                    }
                                }
                            }
                        }
                    }
                   
                    if (BehaviourScript.state == 2)
                    {
                        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
                        foreach (GameObject spawner in spawners)
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
}
