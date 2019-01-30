using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RaceLevelCont : MonoBehaviour {

    public bool snailFinish;
    public bool playerFinish;
    public GameObject snail;
    
	void Start () {
        
	}


    void Update()
    {

        
        if (playerFinish == false && snailFinish == true)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerFinish = true;
            gameObject.GetComponent<Animator>().Play("LevelComplete");
            Destroy(snail);
        }
        if (other.tag == "RaceSnail")
        {
            snailFinish = true;
        }
    }



}
