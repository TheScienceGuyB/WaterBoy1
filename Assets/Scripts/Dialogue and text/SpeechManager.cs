using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SpeechManager : MonoBehaviour {



    public Text dialogueText;
    public Text nameText;
    public Image sprite;
    public Rigidbody2D playerRB;
    public PlayerUI playerWet;
    public GameObject dBox;
    public Queue<string> sentences;
    public bool dialogueActive;
    private AudioSource audioS;


	void Start () {
        sentences = new Queue<string>();
        audioS = gameObject.GetComponent<AudioSource>();
	}


    private void Update()
    {
        if (Input.GetButtonUp("Interact") && dialogueActive == true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
        
    {
        sprite.sprite = dialogue.sprite;
        audioS.Play();
        playerRB.bodyType = RigidbodyType2D.Static;
        playerWet.enabled = false;
        dBox.SetActive(true);
        dialogueActive = true;
        Debug.Log("starting");
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }

    public  void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            playerRB.bodyType = RigidbodyType2D.Dynamic;
            playerWet.enabled = true;
            dBox.SetActive(false);
            dialogueActive = false;
            EndDialogue();
            return;
        }

        audioS.Play();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            
            yield return null;
           
        }
        audioS.Stop();
    }

    void EndDialogue()
    {
        Debug.Log("end");
    }
}
