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
    enum BehaviorState {TheRobot, Idle, Test, KungFu, Surrender, Move};
    int i = 0;
    public static int state = 1;
    public bool staticRobot;
    BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = BehaviorState.Move;
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
        Debug.Log(currentState);
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
                    KungFu();
                    break;
                case 4:
                    TheRobot();
                    break;
                case 5:
                    Surrender();
                    break;
                default:
                    Debug.Log("Switch error");
                    break;
            }
        }
        
        else if(staticRobot)
        {
            switch (state)
            {
                case 1:
                    StaticMove();
                    break;
                case 2:
                    StaticIdle();
                    break;
                case 3:
                    StaticKungFu();
                    break;
                case 4:
                    StaticTheRobot();
                    break;
                case 5:
                    StaticSurrender();
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

        StaticIdle();

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
        currentState = BehaviorState.Move;
        //StaticMove();
        
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

    void KungFu()
    {
        GetComponent<Animator>().Play("kungFu");
        currentState = BehaviorState.KungFu;
    }
    void TheRobot()
    {
        GetComponent<Animator>().Play("theRobot");
        currentState = BehaviorState.TheRobot;
    }
    void Surrender()
    {
        GetComponent<Animator>().Play("Surrender");
        agent.destination = transform.position;
        currentState = BehaviorState.Surrender;
    }

    void StaticIdle()
    {
        GetComponent<Animator>().Play("Still");
    }
    void StaticTheRobot()
    {
        GetComponent<Animator>().Play("theRobot");
    }
    void StaticKungFu()
    {
        GetComponent<Animator>().Play("kungFu");
    }
    void StaticSurrender()
    {
        GetComponent<Animator>().Play("Surrender");
    }
    void StaticMove()
    {
        GetComponent<Animator>().Play("RobotWalk");
        //Move();
    }

}
