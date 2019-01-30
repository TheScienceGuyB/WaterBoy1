using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : MonoBehaviour {

    private float slowMoTimeScale;
    private float fastMoTimeScale;
    private float factor = 4f;


	void Start () {
        slowMoTimeScale = Time.timeScale / factor;
        slowMoTimeScale = Time.timeScale * factor;

		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Jump") && gameObject.GetComponent<PlayerController>().isGrounded != true )
        {
            Time.timeScale = 0;

        }
       




    }
}
