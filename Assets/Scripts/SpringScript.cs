using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour {


    public Sprite springWound;
    public Sprite springUnwond;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    public GameObject playerpos;
    public float forceTime = 1;
    public int force = 3500;
    public int horizontalForce = 0;
    public bool disableControl = false;


    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            
            Debug.Log("playerHit");
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerpos.transform.position, 1f);
            StartCoroutine(Spring());
        }
    }
   
    
    IEnumerator Spring()
    {
        if (disableControl == true)
        {
            player.GetComponent<PlayerController>().enabled = false;
        }
        player.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
        spriteRenderer.sprite = springUnwond;
        
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontalForce, force));
        yield return new WaitForSeconds(forceTime);

       
        spriteRenderer.sprite = springWound;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));

        StopCoroutine(Spring());
        //StopAllCoroutines();
    }
}
