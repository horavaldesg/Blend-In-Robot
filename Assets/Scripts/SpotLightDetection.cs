using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        AnimatorClipInfo[] currentClip;
        currentClip = other.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);
        Debug.Log(currentClip[0].clip.name);
    }
}
