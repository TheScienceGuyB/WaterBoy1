using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScroll : MonoBehaviour
{


    public float colDepth = 2f;
    public float zPosition = 0f;
    public GameObject door;
    private Transform leftCollider;
    private Transform rightCollider;
    private Transform currentPos;
    private Vector3 cameraPos;
    private Vector2 screenSize;
    private Vector2 currentScreenSize;

    public bool bossDead = false;

    void Start()
    {
        StartCoroutine(WaitForScreenSize());
    }
    IEnumerator WaitForScreenSize()
    {
        yield return new WaitForSeconds(.1f);

        leftCollider = new GameObject().transform;
        rightCollider = new GameObject().transform;

        leftCollider.name = "LeftCollider";
        rightCollider.name = "RightCollider";

        leftCollider.gameObject.AddComponent<BoxCollider2D>();
        rightCollider.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.gameObject.layer = 13;
        rightCollider.gameObject.layer = 13;

        leftCollider.parent = transform;
        rightCollider.parent = transform;

        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 4, colDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 4, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
    }

    private void Update()
    {
        currentPos = gameObject.transform;
        if (bossDead == false)
        {
            gameObject.transform.Translate(3f * Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.position = currentPos.position;
            door.SetActive(true);
        }
        
            
    }

    //private void Update()
    //{
    //    currentScreenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
    //    currentScreenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

    //    if (currentScreenSize.x != screenSize.x || currentScreenSize.y != screenSize.y)
    //    {
    //        screenSize.x = currentScreenSize.x;
    //        screenSize.y = currentScreenSize.y;
    //        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
    //        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
    //        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
    //        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);

    //    }
    //}

}


