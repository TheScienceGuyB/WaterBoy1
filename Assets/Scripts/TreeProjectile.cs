using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-6, 0);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            Destroy(gameObject);
        }
    }



}
