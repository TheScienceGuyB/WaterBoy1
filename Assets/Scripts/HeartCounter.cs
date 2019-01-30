using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCounter : MonoBehaviour {

    public int heartNumber;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (heartNumber > FindObjectOfType<PlayerInteractibles>().hearts)
        {
            gameObject.GetComponent<Image>().enabled = false;
            
        }
        if (heartNumber <= FindObjectOfType<PlayerInteractibles>().hearts)
        {
            gameObject.GetComponent<Image>().enabled = true;
           
        }

	}
}
