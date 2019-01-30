using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballProjectile : MonoBehaviour {

    float timer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            Destroy(gameObject);
        }

	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
