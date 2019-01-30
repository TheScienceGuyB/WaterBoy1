using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watergunsnail : MonoBehaviour {

    public GameObject waterBall;
    public Transform waterBallPos;
    public float timer;
    
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;


        if (timer >= .1f)
        {
            Waterballs();
            timer = 0;
        }

	}


    public void Waterballs()
    {
        Debug.Log("shart");
        GameObject projectile = Instantiate(waterBall, waterBallPos.position, Quaternion.identity);
    }
}
