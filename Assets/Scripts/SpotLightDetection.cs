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
            if (hit.collider.tag == "Player")
            {
                GetComponentInParent<Animator>().enabled = false;
                GetComponentInParent<Light>().spotAngle = Mathf.Lerp(GetComponentInParent<Light>().spotAngle, 20, Time.deltaTime);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimatorClipInfo[] currentClip;
        currentClip = other.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
        Debug.Log(currentClip[0].clip.name);
        
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Light>().spotAngle = Mathf.Lerp(GetComponentInParent<Light>().spotAngle, 30, Time.deltaTime);
        GetComponentInParent<Animator>().enabled = true;
    }
    private void OnTriggerStay(Collider other)
    {
        
        
    }
}
