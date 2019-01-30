using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChipperHealth : MonoBehaviour {

    public int health = 100;
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<ColliderScroll>().bossDead = true;
        }

        if (health <= 49)
        {
            gameObject.GetComponent<WoodChipperBoss>().StopPhaseone();
            gameObject.GetComponent<WoodChipperBoss>().enabled = false;
            gameObject.GetComponent<WoodChipperBossPhase2>().enabled = true;
        }



    }
}
