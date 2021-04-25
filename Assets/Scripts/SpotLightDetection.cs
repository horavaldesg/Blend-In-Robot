using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightDetection : MonoBehaviour
{
    public Transform lightTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //GetComponentInParent<Animator>().enabled = false;

            //lightTransform.position = new Vector3(other.transform.position.x, lightTransform.position.y, lightTransform.position.z);
            //GetComponentInParent<Light>().spotAngle = Mathf.Lerp(GetComponentInParent<Light>().spotAngle, 20, Time.deltaTime);

            AnimatorClipInfo[] currentClip;
            AnimatorClipInfo[] currentAnim;
            currentAnim = AnimationController.clipInfo;
            currentClip = other.GetComponent<Collider>().GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
            //Debug.Log("Player Clip: " + currentClip[0].clip.name);
            //Debug.Log("Universal Clip: " + currentAnim[0].clip.name);


            if (currentClip[0].clip.name == currentAnim[0].clip.name)
            {
                //Debug.Log(currentAnim[0].clip.name);
                //Debug.Log(currentClip[0].clip.name);
                Debug.Log("Correct");
            }
            else
            {
                //Debug.Log(currentAnim[0].clip.name);
                //Debug.Log(currentClip[0].clip.name);
                Debug.Log("Wrong Anim");
            }


        }

    }
    void GrowSpotLight()
    {

        GetComponentInParent<Light>().spotAngle = 30;
        GetComponentInParent<Animator>().enabled = true;
    }
    void PlayerDetection()
    {

    }
}
