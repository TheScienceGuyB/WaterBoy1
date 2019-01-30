using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class TurnOnSpeech : MonoBehaviour
{
    public bool speechOn;


    private void Update()
    {
        if (speechOn == true)
        {
            gameObject.GetComponent<SpeechTrigger>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpeechTrigger>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
        
    {
        if (other.tag == "Player")
        {
            speechOn = true;
        }   
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            speechOn = false;
        }
    }

}

