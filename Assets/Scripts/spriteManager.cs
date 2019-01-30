using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteManager : MonoBehaviour {

    public PlayerController playerMove;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);



        if (playerMove.waterGun == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        
        if (mousePos.y >= .5)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.y <= .4999)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
	}
}
