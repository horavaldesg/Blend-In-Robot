using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    public GameObject robot;
    public Transform spawnerTransform;
    [SerializeField] float spawnRate = 3;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(robot, spawnerTransform);
    }

    // Update is called once per frame
    void Update()
    {
       
        i += Time.deltaTime;
        Debug.Log(i);
        if(i > spawnRate)
        {

            Instantiate(robot, spawnerTransform);
            AnimationController.robots = GameObject.FindGameObjectsWithTag("Robot");
            i = 0;
        }

    }
}
