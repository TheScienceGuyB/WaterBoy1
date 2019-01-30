using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public int waterSat;
    public GameObject inactive;
    public GameObject active;
    public bool isRaining;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (waterSat >= 25)
        {
            inactive.SetActive(false);
            active.SetActive(true);
            isRaining = true;
        }
	}



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WaterBall")
        {
            waterSat += 1;
        }
    }


    public void Setinactive()
    {
        Destroy(gameObject);
    }



}
