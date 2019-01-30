using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PlayerInteractibles : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Vector3 respawnPosition;
    private GameObject player;
    public PlayerUI playerWet;
    public int health = 200;
    public int hearts;
    public bool invincible;
    public PlayerController playerMovement;
    public float zeroWetness;
   
        
    Animator playerAnim;



    // Use this for initialization
    void Start()
    {
        hearts = 3;
        myRigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<GameObject>();
        playerAnim = GetComponent<Animator>();
            

    }

    

    // Update is called once per frame
    void Update()
    {
        

        float currentWet = playerWet.wetness;
        


        if (hearts <= 0)
        {

            transform.position = respawnPosition;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            myRigidBody.velocity = new Vector3(0f, 0f, 0f);
            
            health = 200;
            playerWet.wetness = 100f;
            
        }
        if (health > 200)
        {
            health = 200;
                
        }
        if (hearts > 3)
        {
            hearts = 3;
        }
        if (playerWet.wetness <= 0)
        {
            zeroWetness += Time.deltaTime;
        }
        else
        {
            zeroWetness = 0f;
        }
        if (zeroWetness >= 3f)
        {
            hearts-= 1;
            zeroWetness = 0f;
        }


        


    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            // How to Deactivate things (checkbox)
            //gameObject.SetActive(false);

            hearts = 0;
            playerMovement.moveSpeed = 500;
        }
        if (other.tag == "CheckPoint")
        {
               
            respawnPosition = other.transform.position;
        }
        if (!invincible)
        {
            if (other.tag == "Enemy")
            {
                FindObjectOfType<AudioManager>().Play("Hit Sound");           
                hearts -= 1;
                playerAnim.SetBool("Hurt", true);
                //to reset speed from speedboosts
                playerMovement.moveSpeed = 500;
                StartCoroutine(Invincibility());
            } 
        }
        
        if (other.tag == "ReverseFish")
        {
            StartCoroutine(Reverse(other));
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!invincible)
        {
            if (other.tag == "Enemy")
            {
                FindObjectOfType<AudioManager>().Play("Hit Sound");
                hearts -= 1;
                playerAnim.SetBool("Hurt", true);
                //to reset speed from speedboosts
                playerMovement.moveSpeed = 500;
                StartCoroutine(Invincibility());
            }
        }
    }



    public void PlayerNotHurt()
    {
        playerAnim.SetBool("Hurt", false);
    }

    IEnumerator Reverse(Collider2D player)
    {
        playerAnim.SetBool("Confused", true);
        GameObject.FindObjectOfType<IceState>().iceStateActive = false;
        //playerAnim.Play("PlayerConfused");
        playerMovement.moveSpeed = -playerMovement.moveSpeed;
        playerMovement.vMoveSpeed = -playerMovement.vMoveSpeed;     
        yield return new WaitForSecondsRealtime(2);
        playerMovement.moveSpeed = Mathf.Abs(playerMovement.moveSpeed);
        playerMovement.vMoveSpeed = Mathf.Abs(playerMovement.vMoveSpeed);
        //playerAnim.StopPlayback();  
        playerAnim.SetBool("Confused", false);
        GameObject.FindObjectOfType<IceState>().iceStateActive = true;

    }

    IEnumerator Invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(.5f);
        invincible = false;
    }

}

