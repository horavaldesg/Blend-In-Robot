using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TargetSript : MonoBehaviour
{
    GameObject cameraObj;
    public bool changeScene;
    public bool restart;
    public string scene;
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

        
    }
    private void OnTriggerEnter(Collider other)
    {
        
            if (other.tag == "Robot")
            {
                Destroy(other.gameObject);
            }
        if (changeScene)
        {
            if (other.tag == "Player")
            {
                
                if (restart)
                {
                    Score.gameOver = true;
                    ScoreText.score = 0;
                    GameObject[] audioObj = GameObject.FindGameObjectsWithTag("Audio");
                    GameObject scoreContainer = GameObject.FindGameObjectWithTag("Score");
                    Destroy(scoreContainer);
                    foreach(GameObject audio in audioObj)
                    {
                        Destroy(audio);
                    }
                    
                }
                SceneManager.LoadScene(scene);
            }
        }
    }
}
