using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCharacter : MonoBehaviour
{


    Animator anim;
    public CharacterController cc;
    public Transform checkPos;
    public LayerMask groundMask;
    public float speed = 5f;
    public float verticalSpeed = 0;
    public float Gravity = -9.8f;
    public float jumpSpeed = 9;
    public bool grounded;
    public static Vector2 coord;


    private float facingZ = 1;
    private float facingX = 1;




    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Brednan Edits
        Controls();
        Movement();


        //movement

        Vector3 movement = Vector3.zero;

        float xSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        movement += transform.forward * xSpeed;
        float zSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement += transform.right * zSpeed;
        anim.SetFloat("Speed Forward", movement.magnitude);

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
            verticalSpeed = jumpSpeed;
        }

        //RaycastHit hit;
        //if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, 6))
        //{


        //}
        //cc.Move(movement);
    }

    void Controls()
    {
        float inputZ = (Input.GetAxisRaw("Vertical"));
        float inputX = (Input.GetAxisRaw("Horizontal"));

        facingZ = inputZ;
        facingX = inputX;
    }

    void Movement()
    {
        //Debug.Log("facingY = " + facingY);
        //Debug.Log("facingX = " + facingX);

        //W
        if (facingZ > 0)
        {

            //FIX ME
            if(transform.eulerAngles.y > 0)
            {
                transform.localEulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * 4f);
            }
            else if (transform.eulerAngles.y < 0)
            {
                transform.localEulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 360f, 0f), Time.deltaTime * 4f);
            }
            
            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
        //A
        if (facingX > 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
            transform.position += new Vector3(Time.deltaTime, 0);
        }
        //S
        if (facingZ < 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 4f);
            transform.position += new Vector3(0, 0, -Time.deltaTime);
        }
        //D
        if (facingX < 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
    }
}
