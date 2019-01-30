using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seaweed : MonoBehaviour {


    public PlayerController playermovement;
    public bool slowMovement;


    private void Start()
    {
        playermovement = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            slowMovement = true;

            StartCoroutine(MoveSlow());
 
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            slowMovement = false;
        }
    }

    IEnumerator MoveSlow()
    {
        while (slowMovement == true)
        {
            playermovement.moveSpeed = 80f;
            playermovement.vMoveSpeed = 80f;
            playermovement.jumpSpeed = 0f;
            
            yield return null;
        }
           
            yield return new WaitForSeconds(.7f);


        playermovement.jumpSpeed = playermovement.normalJumpSpeed;
        playermovement.moveSpeed = playermovement.normalSpeed;
        playermovement.vMoveSpeed = playermovement.vnormalSpeed;
        

        
    }

}
