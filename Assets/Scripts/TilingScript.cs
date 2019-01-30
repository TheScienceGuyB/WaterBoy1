using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]

public class TilingScript : MonoBehaviour {

    public int offsetX = 6;

    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;
    private float spriteWidth = 0f;
    public Camera cam;
    private Transform myTransform;

    private void Awake()
    {
        
        myTransform = transform;
    }

    // Use this for initialization
    void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (hasARightBuddy == false || hasALeftBuddy == false)
        {
            // calc cameras extent (half of width in x+ direction
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calc where the camera can see the edge of the ground
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) - camHorizontalExtend;


            if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }else if(cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }

	}

    void MakeNewBuddy(int rightOrLeft)
    {
        Vector3 newPosition = new Vector3((myTransform.position.x + myTransform.localScale.x*spriteWidth * rightOrLeft),myTransform.position.y,myTransform.position.z);
        Transform newBuddy =  Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;


        // if object is not tileable
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = myTransform.parent;

        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<TilingScript>().hasALeftBuddy = true;
        }else
        {
            newBuddy.GetComponent<TilingScript>().hasARightBuddy = true;
        }
    }
}
