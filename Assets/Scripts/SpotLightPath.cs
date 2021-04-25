using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpotLightPath : MonoBehaviour
{
    public GameObject player;
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    AudioSource audioSc;
    //Rigidbody rb;
    float speed = 3f;
    float minDistance = 1;
    float safeDistance = 10;
    float specPos = 20;
    public enum BehaviorState { Move, Flee };

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case BehaviorState.Move:
                Move();
                break;
            case BehaviorState.Flee:
                Flee();
                break;
            default:
                Debug.Log("Switch error");
                break;
        }



    }


    void Flee()
    {

        Vector3 differenceVector = transform.position - target.position;
        if (differenceVector.magnitude < safeDistance)
        {
            agent.destination = transform.position + differenceVector;


        }
        else
        {

            agent.destination = transform.position;
        }


    }
    void Move()
    {
        Vector3 differenceVector = target.position - transform.position;
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
