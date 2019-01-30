using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastSlug : MonoBehaviour {

    public GameObject blast;
    Vector2 currentPos;
    public Transform blastPos;
    public Transform blastPos1;
    public Transform blastPos2;

    public GameObject freeze;
    public int x;
    public int location;

    public Vector2 speed1;
    public Vector2 speed2;
    public Vector2 speed3;

    float shotTImer;

	void Start () {
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
    }
	
	// Update is called once per frame
	void Update () {

        shotTImer += Time.deltaTime;
       // location = x + 1;

        /*
        switch (location)
        {
            case 1:
                currentPos.x = blastPos.transform.position.x;
                currentPos.y = blastPos.transform.position.y;
                break;
            case 2:
                currentPos.x = blastPos1.transform.position.x;
                currentPos.y = blastPos1.transform.position.y;
                break;
            case 3:
                currentPos.x = blastPos2.transform.position.x;
                currentPos.y = blastPos2.transform.position.y;
                break;

        }
      */  

	}
    public void FixedUpdate()
    {
        if (shotTImer >= 3)
        {
            Shoot();
            shotTImer = 0;

        }
    }


    public void Shoot()
    {
        GameObject Blast = Instantiate(blast, blastPos.transform.position, Quaternion.identity);
        GameObject Blast1 = Instantiate(blast, blastPos1.transform.position, Quaternion.identity);
        GameObject Blast2 = Instantiate(blast, blastPos2.transform.position, Quaternion.identity);
        Blast.GetComponent<Rigidbody2D>().velocity = speed1;
        Blast1.GetComponent<Rigidbody2D>().velocity = speed2;
        Blast2.GetComponent<Rigidbody2D>().velocity = speed3;
        
    }
}
    





