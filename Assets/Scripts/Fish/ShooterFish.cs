using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFish : MonoBehaviour {

    public Transform target;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;
    public GameObject projectile;
    public Vector2 playerCheckSize;
    public float projectileSpeed;
    public bool playerNear;
    float timer;
    public int waitingTime;

    
    
    
    
    // Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        playerNear = Physics2D.OverlapBox(playerCheck.position, playerCheckSize, 0f, whatIsPlayer);
        //float probability = Time.deltaTime * shotsPerSecond;
        if (playerNear == true && timer > waitingTime)
        {

           
            Fire();
            timer = 0f;
        }
    }


    void Fire()
    {
        Vector3 startPosition = transform.position;
        Vector3 direction = (Vector3)target.position - startPosition;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity);
        missile.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        missile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    

}
