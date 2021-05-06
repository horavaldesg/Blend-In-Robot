using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSpawner : MonoBehaviour
{
    public GameObject robot;
    public Transform spawnerTransform;
    public string target;
    [SerializeField] float spawnRate = 3;
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Instantiate(robot, spawnerTransform);
        BehaviourScript.targetStr = target;

    }

    // Update is called once per frame
    void Update()
    {
       
        i += Time.deltaTime;
        //Debug.Log(i);
        if(i > spawnRate)
        {
           
            GameObject robotObj = Instantiate(robot, spawnerTransform);
            //robotObj.GetComponent<BehaviourScript>().targetLocation = GameObject.FindGameObjectWithTag(target);
            BehaviourScript.targetStr = target;
            i = 0;
        }

    }
}
