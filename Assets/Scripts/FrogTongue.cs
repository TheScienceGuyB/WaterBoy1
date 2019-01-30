using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogTongue : MonoBehaviour {

    public GameObject player;
    public Transform tongueTip;
    public bool isStuck = false;


    private void Start()
    {
        player = GameObject.Find("Player");
    }


    private void Update()
    {

        if (isStuck == true)
        {
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(1.5f, 1.5f);
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(.987f, .298f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            
            
            StartCoroutine(HitboxExpand());
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player"){
            player.GetComponent<PlayerController>().enabled = false;
            player.transform.position =new Vector2(tongueTip.position.x, tongueTip.position.y);
            //other.transform.parent = tongueTip;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            player.GetComponent<PlayerController>().enabled = true;
            
            isStuck = false;
            
        }
            
    }

    IEnumerator HitboxExpand()
    {
        Debug.Log("starting hitbox");
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        isStuck = true;
        
        yield return new WaitForSeconds(1f);
        isStuck = false;

    }
}
