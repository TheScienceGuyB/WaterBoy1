using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour {

    public GameObject trashSmell;
    float shotTimer;
    public int water;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shotTimer += Time.deltaTime;

        if (shotTimer >= 1f)
        {
            GameObject oil = Instantiate(trashSmell, new Vector2(transform.position.x, transform.position.y +1), Quaternion.identity);
            oil.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
            shotTimer = 0;
        }


        if (water >= 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WaterBall")
        {
            water++;
        }
    }


}
