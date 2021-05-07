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

    float boost = 1;
    public float speedBoost = 5;
    private float facingZ = 1;
    private float facingX = 1;

    AudioSource walk;
    public float animt;


    // Start is called before the first frame update
    void Start()
    {
        boost = 1;
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        walk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            walk.Play();
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            walk.Pause();
        }
        //Brednan Edits
        Controls();
        //Movement();
        Movement3();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            boost = speedBoost;
        }
        else
        {
            boost = 1;
        }
        //movement

        Vector3 movement = Vector3.zero;

        float xSpeed = Input.GetAxis("Vertical") * speed * boost * Time.deltaTime;

        movement += transform.forward * xSpeed;
        float zSpeed = Input.GetAxis("Horizontal") * speed * boost * Time.deltaTime;
        movement += transform.right * zSpeed;
        anim.SetFloat("Speed Forward", movement.magnitude);
        animt -= Time.deltaTime;
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
        float inputZ = Input.GetAxisRaw("Vertical");
        float inputX = Input.GetAxisRaw("Horizontal");

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
            if (transform.localEulerAngles.y < 180)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0, 0f), Time.deltaTime * 4f);
            }
            else if (transform.localEulerAngles.y > 0)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 360, 0f), Time.deltaTime * 4f);
            }

            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
        //D
        if (facingX > 0)
        {
            if (transform.localEulerAngles.y > -90)
            {
                //Debug.Log("Positive");
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90, 0f), Time.deltaTime * 4f);
                //transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z), Quaternion.Euler(0, 90, 0), Time.deltaTime *4f);
            }
            //else if (transform.localEulerAngles.y < -90 )
            //{
            //    Debug.Log("Negative");
            //    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, -270, 0f), Time.deltaTime * 4f);
            //}
            transform.position += new Vector3(Time.deltaTime, 0);
        }
        //S
        if (facingZ < 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 4f);
            transform.position += new Vector3(0, 0, -Time.deltaTime);
        }
        //A
        if (facingX < 0)
        {
            if(transform.localEulerAngles.y > 90) {

            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
            }
            else if (transform.localEulerAngles.y < 90)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, -90f, 0f), Time.deltaTime * 4f);
            }
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
    }

    void Movement2()
    {

        //W
        if (facingZ > 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0, 0f), Time.deltaTime * 4f);

            transform.position += new Vector3(0, 0, Time.deltaTime);
        }
        //S
        else if (facingZ < 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 4f);
            transform.position += new Vector3(0, 0, -Time.deltaTime);
        }
        //A
        if (facingX < 0)
        {
            if (transform.localEulerAngles.y > 90)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
            }
            else if (transform.localEulerAngles.y < 90)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, -45f, 0f), Time.deltaTime * 4f);
            }
            transform.position += new Vector3(-Time.deltaTime, 0);
        }
       
        //D
         else if (facingX > 0)
        {
            if (transform.localEulerAngles.y > -90)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90, 0f), Time.deltaTime * 4f);
            }
            else if (transform.localEulerAngles.y < -90)
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, -270f, 0f), Time.deltaTime * 4f);
            }
            transform.position += new Vector3(Time.deltaTime, 0);
        }
       
    }
    void Movement3()
    {
        

        Vector3 movement = Vector3.zero;
        //W
        if (facingZ > 0)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 4);
            movement += new Vector3(0, Gravity, Time.deltaTime * speed * boost);
        }
        //S
        else if (facingZ < 0)
        {
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 4);
            movement += new Vector3(0, Gravity, -Time.deltaTime * speed * boost);
        }
        //A
        if (facingX < 0)
        {
            Quaternion rotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 4);
            movement += new Vector3(-Time.deltaTime * speed * boost, Gravity);
        }

        //D
        else if (facingX > 0)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 4);
            movement += new Vector3(Time.deltaTime * speed * boost, Gravity);
        }        
        cc.Move(movement);
    }
}
