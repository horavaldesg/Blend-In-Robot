using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClawAnimation : MonoBehaviour
{
    public static ClawAnimation thisScript;
    // Start is called before the first frame update
    void Start()
    {
        thisScript = this;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public static void ClawPlayer(GameObject claw, GameObject player)
    {
        claw.SetActive(true);
        //GetComponent<Collider>().enabled = false;
        //Time.timeScale = 0;
        Debug.Log("Wrong Anim");
        Debug.Log("PlayerClawed");

        claw.GetComponent<Animator>().Play("ClawGrab");
        player.GetComponent<Animator>().Play("RobotClawwed");
        //SceneManager.LoadScene("Title Screen");

        thisScript.StartCoroutine(thisScript.changeScene(claw));
        
    }
    IEnumerator changeScene(GameObject claw)
    {

        yield return new WaitForSeconds(2.5f);
        GameObject[] audioObj = GameObject.FindGameObjectsWithTag("Audio");
        GameObject scoreContainer = GameObject.FindGameObjectWithTag("Score");
        Destroy(scoreContainer);
        foreach(GameObject audio in audioObj)
        {
            Destroy(audio);
        }
        
        ScoreText.score = 0;
        SceneManager.LoadScene("Title Screen");
    }


}
