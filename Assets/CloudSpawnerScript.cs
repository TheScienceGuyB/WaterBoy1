using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour {

    public GameObject cloudDamage;
    public float timer;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 2)
        {
            GameObject electricCloud = Instantiate(cloudDamage, gameObject.transform.position + new Vector3(0, Random.Range(-15.0f, 15.0f), 0), Quaternion.identity);
            electricCloud.GetComponent<Rigidbody2D>().velocity = new Vector2(14, 0);
            timer = 0;
        }





	}
}
