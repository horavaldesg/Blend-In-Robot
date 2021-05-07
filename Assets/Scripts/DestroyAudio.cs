using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    GameObject audioObj;
    // Start is called before the first frame update
    void Start()
    {
        audioObj = GameObject.FindGameObjectWithTag("Background Audio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyAudioObj()
    {
        Destroy(audioObj);
    }
}
