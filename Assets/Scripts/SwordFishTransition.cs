using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordFishTransition : MonoBehaviour {

    
    public Dialogue dialogue;
    public SpeechManager speechManager;
    
    public string nextLevel;

	void Start () {
        gameObject.GetComponent<SwordFishTransition>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(speechManager.sentences.Count == 0)
        {
            SceneManager.LoadScene(nextLevel);
        }
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player")
        {
            gameObject.GetComponent<SwordFishTransition>().enabled = true;
            FindObjectOfType<SpeechManager>().StartDialogue(dialogue);
            

        }
    }

    


}
