using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideableShark : MonoBehaviour {

    public Transform pos1;
    public int speed = 6;
    public int speed1;
    public bool playerOn = false;
    bool playerHasJumpedOn;
    Vector2 currentPos;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentPos = transform.position;
        if (playerOn == true)
        {
            transform.position = Vector2.MoveTowards(currentPos, new Vector2(pos1.position.x, pos1.position.y), speed * Time.deltaTime);
        }
        else if (playerHasJumpedOn == true && playerOn == false)
        {
            transform.position = Vector2.MoveTowards(currentPos, new Vector2(pos1.position.x, pos1.position.y), speed1 * Time.deltaTime);
        }
        else
        {
            transform.position = currentPos;
        }



	}
    



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            playerOn = true;
            other.transform.parent = transform;
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            playerOn = false;
            other.GetComponent<Animator>().SetBool("OnShark", false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHasJumpedOn = true;
            playerOn = true;
            other.transform.parent = transform;
            other.GetComponent<Animator>().SetBool("OnShark", true);
           
        }
    }






}
