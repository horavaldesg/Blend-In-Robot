using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    public bool randomRobot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] robots;
        
        robots = GameObject.FindGameObjectsWithTag("Robot");
        Debug.Log(robots.Length);
        if (randomRobot)
        {
            RandomRobot(robots);
        }
    }
    void RandomRobot(GameObject[] robots)
    {
        int i = Random.Range(0, robots.Length);
        //robots[i].GetComponent<BehaviourScript>().currentState = BehaviourScript.BehaviorState.Test;
        randomRobot = false;
    }
}
