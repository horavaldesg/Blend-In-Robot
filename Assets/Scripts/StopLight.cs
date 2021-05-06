using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    GameObject[] lights;
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("StopLight");
    }

    // Update is called once per frame
    void Update()
    {
        if (lights != null)
        {
           
            lights = GameObject.FindGameObjectsWithTag("StopLight");
            foreach (GameObject light in lights)
            {
                Color lightColor = light.GetComponent<Light>().color;
                if (lightColor == Color.red)
                {
                    BehaviourScript.state = 2;
                }
                else if (lightColor == Color.red)
                {
                    BehaviourScript.state = 1;
                }
                else if(lightColor == Color.yellow)
                {

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
