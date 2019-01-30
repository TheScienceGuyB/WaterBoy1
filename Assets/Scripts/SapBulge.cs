using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapBulge : MonoBehaviour {

    public Transform spawnpos;
    public GameObject sapDroplet;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SapInstantiate()
    {
        Object.Instantiate(sapDroplet, new Vector2(spawnpos.position.x, spawnpos.position.y), Quaternion.identity);
    }

     

}
