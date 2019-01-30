using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RaceSnail : MonoBehaviour {



    Animator myAnim;
    public GameObject raceTrack;
	// Use this for initialization
	void Start () {
        myAnim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<SpeechTrigger>().sentenceCount == 1)
        {
            myAnim.Play("RaceAnim");
            raceTrack.SetActive(true);
        }



    }


    void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
