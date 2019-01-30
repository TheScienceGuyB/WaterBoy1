using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSwordfishLeft : MonoBehaviour {
    public Transform pos1;
    public Transform pos2;
    public float timeTillRepeat;
    Animator myAnim;
    void Start()
    {
        InvokeRepeating("StartCo", 0, timeTillRepeat);
        myAnim = GetComponent<Animator>();
    }





    void StartCo()
    {
        StartCoroutine(Move1());
    }


    IEnumerator Move1()
    {
        while (transform.position.x != pos1.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos1.position.x, pos1.position.y), 10 * Time.deltaTime);
            myAnim.Play("SwimmingHSwordFLeft");
            yield return null;
        }
        myAnim.Play("FlipRight");
        yield return new WaitForSeconds(.2f);

        while (transform.position.x != pos2.position.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos2.position.x, pos2.position.y), 10 * Time.deltaTime);
            myAnim.Play("SwimmingHSwordF");
            yield return null;
        }
        myAnim.Play("FlipLeft");
        yield return new WaitForSeconds(.2f);
        //yield return new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DisableCollider());
        }

        
    }


    IEnumerator DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(.4f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }



}
