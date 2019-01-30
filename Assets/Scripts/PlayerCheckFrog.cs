using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckFrog : MonoBehaviour {


    public bool playerNear;
    public Transform playerCheck;
    public Vector2 playerCheckSize;
    public LayerMask whatIsPlayer;
    

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize,45, whatIsPlayer);

        if (playerNear == true)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", false);
        }
    }
}
