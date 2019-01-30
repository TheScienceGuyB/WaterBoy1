using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : MonoBehaviour {

    public PlayerUI wetness;
   
    public float duration;
    public float wetRestored;


    private void Start()
    {
        wetness = FindObjectOfType<PlayerUI>();

    }
    private void Update()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(Respawm(other));
            wetness.wetness += Mathf.Clamp(wetRestored, 0, 100);
            //Destroy(gameObject);
            
        }
    }


    IEnumerator Respawm(Collider2D player)
    {
        Debug.Log("starting");
        yield return new WaitForSeconds(duration); //+ icicleAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

        
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;



    }
}
