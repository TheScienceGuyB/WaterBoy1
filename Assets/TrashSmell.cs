using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSmell : MonoBehaviour {

    bool inWater;
    public LayerMask whatIsWater;
    public Transform waterCheck;
    public float waterCheckRadius;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inWater = Physics2D.OverlapCircle(waterCheck.position, waterCheckRadius, whatIsWater);

        if (inWater == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }



}
