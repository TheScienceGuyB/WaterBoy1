using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;
    public float timeTillRepeat;
    public int speed = 6;

    void Start()
    {
        InvokeRepeating("StartCo", 0, timeTillRepeat);
    }

    void StartCo()
    {
        StartCoroutine(Move1());
    }


    IEnumerator Move1()
    {
        while (transform.position.y != pos2.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos2.position.x, pos2.position.y), speed * Time.deltaTime);
            yield return null;
        }
        while (transform.position.y != pos1.position.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos1.position.x, pos1.position.y), speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
    }
}
