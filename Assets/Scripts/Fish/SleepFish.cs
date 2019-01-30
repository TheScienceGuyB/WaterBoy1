using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepFish : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rb2D;
    public Vector2 knockback;

    public Transform target;
    public float speed = 4f;
    //public float timer;
    Animator playerAnim;
    public int waitingTime;
    public Transform playerCheck;
    public bool playerNear;
    public LayerMask whatIsPlayer;
    public Vector2 playerCheckSize;
    private Rigidbody2D rb;
    public LayerMask whatIsWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    private Vector3 startPos;

    public bool inWater;
    public bool frozen = false;
    public GameObject freeze;




    private void Start()
    {
        target = GameObject.Find("Player").transform;
        player = GameObject.Find("Player");
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
        startPos = transform.position;
    }
    private void Update()
    {
        if (playerNear == true)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", false);
        }
        
    }

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        Vector3 currentpos = transform.position;
        
        if (inWater != true)
        {
            rb.AddForce(new Vector2(0, -10));
        }

        if (playerNear && inWater && frozen == false)
        {
            Vector3 direction = target.position - currentpos;
            direction.Normalize();
            //float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);

            transform.Rotate(new Vector3(0, 0, 7));
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            rb.velocity = direction * speed;
        }
        if (frozen == true)
        {
            transform.position = currentpos;
            rb.bodyType = RigidbodyType2D.Static;
        }

        else if (playerNear != true)
        {
            rb.transform.position = Vector3.MoveTowards(currentpos, startPos, .1f);
            transform.rotation = Quaternion.identity;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Knockback(other));
        }
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    
    
        
    

    IEnumerator Knockback(Collider2D player)
    {

        Debug.Log("player collided");
        playerAnim.SetBool("Sleeping", true);
        player.GetComponent<PlayerController>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
       

        rb2D.MovePosition(rb2D.position - knockback * Time.deltaTime);
        rb2D.velocity = new Vector2(5f, 5f);

        yield return new WaitForSeconds(1f);

        playerAnim.SetBool("Sleeping", false);
        player.GetComponent<PlayerController>().enabled = true;
        StartCoroutine(EnableEffect());

    }

    IEnumerator EnableEffect()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.transform.parent = iceBlock.transform;
        yield return new WaitForSeconds(2f);
        frozen = false;
        gameObject.transform.parent = null;
        Destroy(iceBlock);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;

    }



}
