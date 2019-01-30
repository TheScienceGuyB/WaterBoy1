using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowVerticalMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().verticalWaterControl = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().verticalWaterControl = false;
        }
    }
}
