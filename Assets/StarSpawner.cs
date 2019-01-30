using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

    public GameObject star;
    public Transform target;
    public int speed;
    public int secondsTillShot;
    public float timer;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsTillShot)
        {

            Vector3 startPosition = transform.position;
            Vector3 direction = (Vector3)target.position - startPosition;
            direction.Normalize();
            GameObject shootingStar = Instantiate(star, gameObject.transform.position, Quaternion.identity);
            shootingStar.GetComponent<Rigidbody2D>().velocity = direction * speed;
            timer = 0;
        }
    }


}
