using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KnockbackFIsh : MonoBehaviour {

    public GameObject freeze;
    public Transform prefabAnim;
    public bool frozen;
    public GameObject player;
    public Rigidbody2D rb2D;
    public Vector3 knockback;
    public float speed;
    public float vspeed;
    public float duration = 1f;

    public float lengthOfAnimation;



    private void Start()
    {
        player = GameObject.Find("Player");
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        prefabAnim = transform.parent;
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
    }


    private void Update()
    {
        

       

        Vector3 currentpos = transform.position;

        
        if (frozen == true)
        {

            transform.position = currentpos;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
        else if (frozen == false)
        {
            
           
            
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("BITCH");
            StartCoroutine(Knockback(other));
        }
        if (other.tag == "IceBlock")
        {
            frozen = true;
            StartCoroutine(Frozen());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
           
        }
    }

    IEnumerator Knockback (Collider2D player)
    {
        Debug.Log("player collided");
       
        player.GetComponent<PlayerController>().enabled = false;
        rb2D.velocity = new Vector2(0f, 0f);
        Vector3 currentpos = player.GetComponent<Rigidbody2D>().transform.position;
        

        //rb2D.transform.position = Vector3.MoveTowards(currentpos, currentpos - knockback, speed);
        rb2D.velocity = new Vector2(speed, vspeed);
        //rb2D.MovePosition(rb2D.position - knockback);

        yield return new WaitForSeconds(duration);

        player.GetComponent<PlayerController>().enabled = true;

    }
    IEnumerator Frozen()
    {
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent = iceBlock.transform;
        yield return new WaitForSeconds(lengthOfAnimation);
        gameObject.transform.parent = prefabAnim.transform;
        frozen = false;
        Destroy(iceBlock);
        
    }
    
}
