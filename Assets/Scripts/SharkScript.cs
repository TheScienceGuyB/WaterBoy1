using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour {



   
   
    public bool inWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    public LayerMask whatIsWater;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 currentPos;

    public bool frozen = false;
    GameObject freeze;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.identity;
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        currentPos = transform.position;
        Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 velocity = direction - currentPos;
        velocity.Normalize();
        if (inWater && frozen == false)
        {


            rb.velocity = velocity * speed;
            //Vector2 direction = (Vector2)target.position - rb.position;
            //direction.Normalize();
            // transform.position = Vector2.MoveTowards(currentPos, direction, .17f);
            //transform.position = Vector2.Lerp(currentPos, direction,  1* Time.deltaTime);


        }else if (frozen == true)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            StartCoroutine(GetInWater());
        }

        
    }

    IEnumerator GetInWater()
    {
        rb.velocity = new Vector2(0, -10);
        yield return new WaitForSeconds(1f);
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator Frozen()
    {
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position - new Vector3(0,1,0), Quaternion.identity);
        iceBlock.transform.localScale = new Vector2(3, 3);
        gameObject.transform.parent = iceBlock.transform;  
        yield return new WaitForSeconds(2f);
        frozen = false;
        gameObject.transform.parent = null;
        Destroy(iceBlock);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            frozen = true;
            StartCoroutine(Frozen());
        }
    }

    
}
