using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCharacter : MonoBehaviour
{

    public CharacterController cc;
    public Transform checkPos;
    public LayerMask groundMask;
    public Transform camTransform;

    public float speed = 5f;
    public float verticalSpeed = 0;
    public float Gravity = -9.8f;
    public float jumpSpeed = 9;
    public bool grounded;
    int i;


    public float speedBoost = 3;
    public float speedPlayer;

    public float jumpBoost = 11;
    float jumpInitial;

    float zeroGravity;
    Vector3 initialPos;

    string currentScene;

    // Start is called before the first frame update
    void Start()
    {

        cc = GetComponent<CharacterController>();
        speedPlayer = speed;
        jumpInitial = jumpSpeed;
        zeroGravity = 0;
        initialPos = transform.position;
        //Debug.Log(initialPos);
    }

    // Update is called once per frame
    void Update()
    {




        //movement
        Vector3 movement = Vector3.zero;


        float xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
        movement += transform.forward * xSpeed;
        float zSpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
        movement += transform.right * zSpeed;

       
        //Gravtity

        verticalSpeed += Gravity * Time.deltaTime;
        movement += transform.up * verticalSpeed * Time.deltaTime;

        //Grounded

        if (Physics.CheckSphere(checkPos.position, 0.5f, groundMask) && verticalSpeed <= 0)
        {
            grounded = true;
            verticalSpeed = 0;
        }
        else
        {
            grounded = false;
        }


        //Jump

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            verticalSpeed = jumpInitial;

        }


        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, 6))
        {


        }

        cc.Move(movement);
    }
}
