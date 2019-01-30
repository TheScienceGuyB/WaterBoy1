using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunchofWats : MonoBehaviour {

    public GameObject waterdudes;

	void Start () {
        StartCoroutine(waterSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    IEnumerator waterSpawn()
    {
        int i = 0;
        while (i < 10)
        {
            Vector2 startPosition = transform.position;
            GameObject waterDrops = Instantiate(waterdudes, startPosition, Quaternion.identity);
            waterDrops.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3f, 10f), Random.Range(1f, 2f));
            i++;
            yield return new WaitForSeconds(.2f);
        }
    }

}
