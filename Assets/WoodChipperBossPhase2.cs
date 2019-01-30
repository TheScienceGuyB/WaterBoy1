using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChipperBossPhase2 : MonoBehaviour {

    public GameObject projectile;
    public GameObject fireBall;
    public GameObject waterMelon100;
    public GameObject waterMelon50;
    public GameObject waterMelon25;
    public GameObject Saw;
    public Transform fireBallPos;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    Transform currentPos;
    GameObject waterMelonSpawner;
    int random;
    int randomWaterMelon;

    float fireBallTimer;

    void Start()
    {
        InvokeRepeating("Startco", 1, 1.6f);
   
    }

    // Update is called once per frame
    void Update()
    {
        fireBallTimer += Time.deltaTime;
       
        if (GameObject.FindObjectOfType<WoodChipperAnimScript>().damageZoneActive == true && fireBallTimer > 2)
        {
            GameObject Fireball = Instantiate(fireBall, fireBallPos.position, Quaternion.identity);
            Fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3, -7), Random.Range(1, 3));
            fireBallTimer = 0;
        }
       
        switch (randomWaterMelon)
        {
            case 1:
                waterMelonSpawner = waterMelon100;
                break;
            case 2:
                waterMelonSpawner = null;
                break;
            case 3:
                waterMelonSpawner = waterMelon50;
                break;
            case 4:
                waterMelonSpawner = waterMelon25;
                break;
            case 5:
                waterMelonSpawner = null;
                break;
            case 6:
                waterMelonSpawner = Saw;
                break;

        }



        


        switch (random)
        {
            case 1:
                currentPos = pos1;
                break;
            case 2:
                currentPos = pos2;
                break;
            case 3:
                currentPos = pos3;
                break;


        }


    }




    IEnumerator ProjectileInstantiate()
    {
        random = Random.Range(1, 4);
        randomWaterMelon = Random.Range(1, 7);

        



        yield return new WaitForSeconds(1f);
        int shot = 0;
        while (shot < 1)
        {
            GameObject missile = Instantiate(projectile, currentPos.position, Quaternion.identity);
            GameObject Melon = Instantiate(waterMelonSpawner, currentPos.position + new Vector3(3, 1.5f, 0), Quaternion.identity);
            Melon.transform.parent = missile.transform;
            shot++;
        }
    }





    void Startco()
    {
        StartCoroutine(ProjectileInstantiate());
    }
}
