using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotIcicleScript : MonoBehaviour {

    Vector3 vec3;
    Vector2 currentVelocity;
    Vector2 newVelocity;
	// Use this for initialization
	void Start () {
        currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        newVelocity = new Vector2(currentVelocity.x, currentVelocity.y + Random.Range(-4, 4));
       
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;

       

    }
    
}
