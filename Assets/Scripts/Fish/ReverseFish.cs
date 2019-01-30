using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ReverseFish : MonoBehaviour {

    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
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




    void Start () {

        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
        startPos = transform.position;

    }

    void FixedUpdate()
    {
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        Vector3 currentpos = transform.position;


        if (playerNear && inWater && frozen != true) {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", true);
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.right * speed;

        }
        else
        { 
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", true);
            rb.transform.position = Vector3.MoveTowards(currentpos, startPos, .1f);
            
            //rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
       
        if (currentpos == startPos)
        {
            gameObject.GetComponent<Animator>().SetBool("PlayerNear", false);
        }
        if (frozen == true)
        {
            transform.position = currentpos;
            rb.bodyType = RigidbodyType2D.Static;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Disable());
        }

        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }


    IEnumerator Disable()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(3);
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
