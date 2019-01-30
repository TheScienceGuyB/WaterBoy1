using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ArrestEventNPC : MonoBehaviour {

    public Dialogue dialogue;
    public SpeechManager speechManager;
    public GameObject trappedDrop;
    public PlayableDirector arrestEvent;
    
    void Start () {
		
	}

    private void Update()
    {
        
        
        if (speechManager.sentences.Count == 0)
        {
            trappedDrop.GetComponent<SpriteRenderer>().enabled = true;
            trappedDrop.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SpeechManager>().StartDialogue(dialogue);
            gameObject.GetComponent<ArrestEventNPC>().enabled = true;
        }
    }
}
