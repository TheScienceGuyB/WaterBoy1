using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSquirt : MonoBehaviour {

    GameObject canvas;
    public bool inkHit = false;
    bool inWater;
    public LayerMask whatIsWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    float timer;
    void Start () {
        canvas = GameObject.FindGameObjectWithTag("InkCanvas");
	}
	
	// Update is called once per frame
	void Update () {
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);
        if (inWater == false)
        {
            StartCoroutine(Destroy());
        }

        //timer += Time.deltaTime;

        //if (timer >= 10f)
        //{
        //    Destroy(gameObject);
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("hit");
            FindObjectOfType<SquidScript>().inkUp = true;
            StartCoroutine(Destroy());
        }
        if (other.tag == "Player" && FindObjectOfType<SquidScript>().inkUp == true) 
        {
            FindObjectOfType<SquidScript>().refreshTimer = 0;
        }
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }


    



}
