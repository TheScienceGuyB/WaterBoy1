using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotScript : MonoBehaviour {
    Vector2 currentVelocity;
    Vector2 newVelocity;
	// Use this for initialization
	void Start () {
        currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        newVelocity = currentVelocity * 1.75f;
        gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
