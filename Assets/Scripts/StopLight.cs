using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    GameObject[] lights;
    [SerializeField] GameObject[] stopLights;
    int lightLength = 0;
    [SerializeField]int rate;

    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("StopLight");
        foreach(GameObject light in stopLights)
        {
            light.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    BehaviourScript.state = 2;
                }
                else if (lightColor == Color.green)
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
