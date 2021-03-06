using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpotLightDetection : MonoBehaviour
{
    BehaviourScript bs;
    GameObject claw;
    GameObject player;
    public Transform lightTransform;
    Color initialColor;
    Color red;
    int r = 0;
    GameObject[] robots;
   
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        claw = GameObject.FindGameObjectWithTag("Claw");
        //claw.SetActive(false);
        initialColor = GetComponentInParent<Light>().color;
        red = new Color(0.811f, 0.333f, 0.333f, 1.000f);
        GetComponentInParent<Light>().color = Color.yellow;
        //Debug.Log(initialColor);
        


    }

    // Update is called once per frame
    void Update()
    {
        robots = GameObject.FindGameObjectsWithTag("Robot");



        RaycastHit hit;
        if (Physics.Raycast(lightTransform.position, lightTransform.forward, out hit))
        {
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            GrowSpotLight();
        GetComponentInParent<Light>().color = Color.yellow;
    }
    private void OnTriggerStay(Collider other)
    {
        AnimatorClipInfo[] currentClip;
        AnimatorClipInfo[] currentAnim;
        
        
        
        if (other.tag == "Player")
        {
            //GetComponentInParent<Animator>().enabled = false;

            //lightTransform.position = new Vector3(other.transform.position.x, lightTransform.position.y, lightTransform.position.z);
            //GetComponentInParent<Light>().spotAngle = Mathf.Lerp(GetComponentInParent<Light>().spotAngle, 20, Time.deltaTime);

            
            
            currentClip = other.GetComponent<Collider>().GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            foreach (GameObject robot in robots)
            {

                if (robot != null)
                {
                    currentAnim = robot.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
                    if (currentClip[0].clip.name == currentAnim[0].clip.name)
                    {
                        //Debug.Log(currentAnim[0].clip.name);
                        GetComponentInParent<Light>().color = Color.green;
                        //Debug.Log(currentClip[0].clip.name);
                        Debug.Log("Correct");
                    }
                    else if (currentClip[0].clip.name != currentAnim[0].clip.name)
                    {
                        //Debug.Log(currentAnim[0].clip.name);
                        GetComponentInParent<Light>().color = red;
                        //ClawPlayer();
                        ClawAnimation.ClawPlayer(claw, player);
                        //StartCoroutine(changeScene());
                        //Debug.Log(currentClip[0].clip.name);
                        //claw.SetActive(true);
                        //Debug.Log("Wrong Anim");
                    }
                }

            }
            //Debug.Log("Player Clip: " + currentClip[0].clip.name);
            //Debug.Log("Universal Clip: " + currentAnim[0].clip.name);





        }

    }
    void GrowSpotLight()
    {

        GetComponentInParent<Light>().spotAngle = 30;
        GetComponentInParent<Animator>().enabled = true;
    }
    
    

}
