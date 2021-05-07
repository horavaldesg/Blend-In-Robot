using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetSript : MonoBehaviour
{
    GameObject cameraObj;
    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StopLight.trigger = true;
            cameraObj.GetComponent<Camera>().fieldOfView = 85;
        }
            
        /*
        if(other.tag == "Robot")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("End");
        }
        */
    }
}
