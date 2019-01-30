using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public SpeechManager speechManager;
    public Dialogue dialogue;
    


    public void TriggerDialogue()
    {
  
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (speechManager.dialogueActive == false && Input.GetButtonUp("Interact"))
        {
            FindObjectOfType<SpeechManager>().StartDialogue(dialogue);
            Debug.Log("starting");
           
        }
    }
}
