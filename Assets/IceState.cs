using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceState : MonoBehaviour {

    public PlayerUI playerUI;
    public PlayerInteractibles playerInterac;
    Rigidbody2D myRigidBody;
    public bool iceblockActive = false;
    public bool iceblockActiveWater = false;
    public bool iceStateActive = true; // allows player to actually use the ability
    public float iceBlockTimer;
    public float iceBlockActiveTimer;
    public float currentWetness;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool inWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    public LayerMask whatIsWater;
    Animator myAnim;

    void Start () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnim = gameObject.GetComponent<Animator>();

	}


    private void Update()
    {
        iceBlockActiveTimer += Time.deltaTime;

        if (iceblockActive == true)
        {
            playerUI.wetness = currentWetness;
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);

        if (iceblockActive == true)
        {
            playerInterac.invincible = true;
        }
        if (iceblockActiveWater == true)
        {
            playerInterac.invincible = true;
        }
        if (iceStateActive == true)
        {
            if (Input.GetButtonDown("Jump") && isGrounded != true && iceBlockActiveTimer >= 5 && inWater != true)
            {
                gameObject.GetComponent<Animator>().SetBool("IceBlock", true);
                Debug.Log("pressed in air");
                StartCoroutine("IceBlock");

            }
            if (Input.GetButtonDown("Jump") && inWater == true && iceBlockActiveTimer >= 5)
            {
                gameObject.GetComponent<Animator>().SetBool("IceBlock", true);
                Debug.Log("pressed in air");
                StartCoroutine("IceBlockWater");

            }

            if (Input.GetButtonDown("Jump") && iceblockActive == true)
            {

                Debug.Log("stopping");
                StopCoroutine("IceBlock");
                StopCoroutine("IceBlockWater");
                gameObject.GetComponent<Animator>().SetBool("IceBlock", false);
                gameObject.GetComponent<PlayerController>().enabled = true;
                iceblockActive = false;
                myRigidBody.velocity = new Vector2(0, 0);
                iceBlockActiveTimer = 0;
                playerInterac.invincible = false;
            }

            if (Input.GetButtonDown("Jump") && iceblockActiveWater == true)
            {

                Debug.Log("stopping");
                StopCoroutine("IceBlock");
                StopCoroutine("IceBlockWater");
                gameObject.GetComponent<Animator>().SetBool("IceBlock", false);
                gameObject.GetComponent<PlayerController>().enabled = true;
                iceblockActiveWater = false;
                myRigidBody.velocity = new Vector2(0, 0);
                iceBlockActiveTimer = 0;
                playerInterac.invincible = false;
            }
        }
            
    }



    IEnumerator IceBlock()
    {
        currentWetness = playerUI.wetness;
        
        yield return new WaitForSeconds(.1f);
        iceblockActive = true;
        gameObject.GetComponent<PlayerController>().enabled = false;
        myRigidBody.velocity = new Vector2(0, 0);

        //yield return new WaitForSeconds(.5f);
        while (isGrounded == false)
        {
            myRigidBody.velocity = new Vector2(0, -800 * Time.deltaTime);
            yield return null;
        }
        myRigidBody.velocity = new Vector2(0, 0);
        gameObject.GetComponent<Animator>().SetBool("IceBlock", false);
        gameObject.GetComponent<PlayerController>().enabled = true;
        iceblockActive = false;
        playerInterac.invincible = false;
        iceBlockActiveTimer = 0;
    }

    IEnumerator IceBlockWater()
    {
        

        yield return new WaitForSeconds(.1f);
        iceblockActiveWater = true;
        gameObject.GetComponent<PlayerController>().enabled = false;
        myRigidBody.velocity = new Vector2(0, 0);

        //yield return new WaitForSeconds(.5f);
        while (inWater == true)
        {
            myRigidBody.velocity = new Vector2(0, 800 * Time.deltaTime);
            yield return null;
        }
        myRigidBody.velocity = new Vector2(0, 0);
        gameObject.GetComponent<Animator>().SetBool("IceBlock", false);
        gameObject.GetComponent<PlayerController>().enabled = true;
        iceblockActiveWater = false;
        playerInterac.invincible = false;
        iceBlockActiveTimer = 0;
    }

}
