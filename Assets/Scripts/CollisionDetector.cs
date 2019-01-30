using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {

    public GameObject waterfallForce;
    public float time = 1;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DisableForce());
        }
    }


    IEnumerator DisableForce()
    {
        waterfallForce.GetComponent<AreaEffector2D>().enabled = false;

        yield return new WaitForSeconds(time);
        waterfallForce.GetComponent<AreaEffector2D>().enabled = true;
    }
}
