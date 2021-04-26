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
    public enum BehaviorState {Move, Idle, Test};

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {

        GameObject targetLocation = GameObject.FindGameObjectWithTag(GetComponentInParent<RobotSpawner>().target);
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        target = targetLocation.transform;
        player = playerObj;
        audioSc = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case BehaviorState.Move: Move();
                break;
            case BehaviorState.Idle: Idle();
                break;
            case BehaviorState.Test: Test();
                break;
            default: Debug.Log("Switch error");
                break;
        }
        
       
        
    }

    
    void Idle()
    {

        Vector3 differenceVector = transform.position - target.position;

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
        GetComponent<Animator>().Play("Still");
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
}
