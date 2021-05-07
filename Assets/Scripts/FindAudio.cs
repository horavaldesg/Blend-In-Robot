using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAudio : MonoBehaviour
{
    AudioSource audioObj;
    // Start is called before the first frame update
    void Start()
    {
        audioObj = GameObject.FindObjectOfType<AudioSource>();
        Debug.Log(audioObj.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
