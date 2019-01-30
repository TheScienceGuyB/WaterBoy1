using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chest : MonoBehaviour {
    public PlayerController watergun;
    public LevelManager levelMan;
    public int i = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown("Interact"))
        {
            gameObject.GetComponent<Animator>().Play("WaterGunChest");
            i++;
        }
        */
        if (Input.GetButtonDown("Interact")&& i >= 2) {
            gameObject.GetComponent<Animator>().Play("idle");

            // may need this line if the level manager seems buggy
            LevelManager.control.i = 1;
            // set level manager int i to 1, causing watergun to be set to true
            //levelMan.i = 1;

        }
        
	}
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            gameObject.GetComponent<Animator>().Play("WaterGunChest");
            i++;
            Debug.Log("shit");
        }
        
    }
}
