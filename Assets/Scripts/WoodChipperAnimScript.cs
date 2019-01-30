using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChipperAnimScript : MonoBehaviour {

    public bool damageZoneActive;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void boolOn()
    {
        damageZoneActive = true;
    }
    public void boolOff()
    {
        damageZoneActive = false;
    }



}
