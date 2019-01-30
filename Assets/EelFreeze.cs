using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelFreeze : MonoBehaviour {

    public bool frozen = false;
    public GameObject freeze;
    void Start () {
        freeze = GameObject.FindGameObjectWithTag("FreezePower");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Frozen()
    {
        frozen = true;
        GameObject iceBlock = Instantiate(freeze, gameObject.transform.position, Quaternion.identity);
        gameObject.GetComponent<EelScript>().paused = true;
        gameObject.GetComponent<EelScript>().enabled = false;
        yield return new WaitForSeconds(2f);
        frozen = false;
        gameObject.transform.parent = null;
        Destroy(iceBlock);
        gameObject.GetComponent<EelScript>().enabled = true;
        gameObject.GetComponent<EelScript>().paused = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "IceBlock")
        {
            StartCoroutine(Frozen());

        }
    }


}
