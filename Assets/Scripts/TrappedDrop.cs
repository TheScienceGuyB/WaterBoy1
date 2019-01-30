using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TrappedDrop : MonoBehaviour {

    public Dialogue dialogue;
    public SpeechManager speechManager;
    
    public PlayableDirector arrestEvent;

    void Start()
    {
        gameObject.GetComponent<Animator>().Play("MoveTrapped");
    }

    private void Update()
    {


        if (speechManager.sentences.Count == 0)
        {
            arrestEvent.enabled = true;
            Destroy(gameObject.GetComponent<TrappedDrop>());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<SpeechManager>().StartDialogue(dialogue);
            gameObject.GetComponent<TrappedDrop>().enabled = true;
        }
    }

    

}
