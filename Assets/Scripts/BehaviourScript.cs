using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BehaviourScript : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    Transform target;
    public static string targetStr;
    AudioSource audioSc;
    public GameObject targetLocation;
    Rigidbody rb;
    float speed = 3f;
    float minDistance = 1;
    float safeDistance = 10;
    float specPos = 20;
    public enum BehaviorState {TheRobot, Idle, Test};
    int i = 0;
    public static int state = 1;
    public bool staticRobot;
    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        if (!staticRobot)
        {
            GameObject targetLocation = GameObject.FindGameObjectWithTag(GetComponentInParent<RobotSpawner>().target);
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            

            target = targetLocation.transform;
            player = playerObj;
            audioSc = GetComponent<AudioSource>();
            agent = GetComponent<NavMeshAgent>();
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (i > 3)
        {
            
            i = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!staticRobot)
        {
            switch (state)
            {
                case 1:
                    Move();
                    break;
                case 2:
                    Idle();
                    break;
                case 3:
                    Test();
                    break;
                default:
                    Debug.Log("Switch error");
                    break;
            }
        }
        else if(staticRobot)
        {
            switch (currentState)
            {
                case BehaviorState.TheRobot:
                    StaticTheRobot();
                    break;
                case BehaviorState.Idle:
                    StaticIdle();
                    break;
                case BehaviorState.Test:
                    Test();
                    break;
                default:
                    Debug.Log("Switch error");
                    break;
            }
        }
       
        
    }

    
    void Idle()
    {


        GetComponent<Animator>().Play("Still");
        agent.destination = transform.position;
        


    }
    void Move()
    {
        Vector3 differenceVector = target.position - transform.position;
        GetComponent<Animator>().Play("RobotWalk");
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target.position;
            //rb.MovePosition(transform.position + moveVector);

        }
        else
        {

            //PlayerMovement.canMove = false;
            agent.destination = transform.position;
        }
    }
    void Test()
    {
        Vector3 differenceVector = target.position - transform.position;
        GetComponent<Animator>().Play("RobotWalk");
        if (differenceVector.magnitude > minDistance)
        {
            agent.destination = target.position;
            //rb.MovePosition(transform.position + moveVector);

        }
        else
        {

            //PlayerMovement.canMove = false;
            agent.destination = transform.position;
        }
    }

    void StaticIdle()
    {
        GetComponent<Animator>().Play("Still");
    }
    void StaticTheRobot()
    {
        GetComponent<Animator>().Play("theRobot");
    }
}
