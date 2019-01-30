using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestEvent : MonoBehaviour {


    public GameObject npcGood;
    public GameObject npcBad;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            npcGood.GetComponent<SpriteRenderer>().enabled = false;
            npcGood.GetComponent<BoxCollider2D>().enabled = false;
            npcBad.GetComponent<SpriteRenderer>().enabled = true;
            npcBad.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
