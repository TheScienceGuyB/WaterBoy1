using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFallScript : MonoBehaviour {

    public GameObject player;
    public GameObject enemies;
    private Collider2D enemyCollider;
	void Start () {
        enemyCollider = enemies.GetComponentInChildren<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {

        enemyCollider = enemies.GetComponentInChildren<Collider2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collider2D myCollider = collision.contacts[0].collider;
        Debug.Log("hitssssss");
    }

   


}
