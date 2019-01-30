using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TutorialSnail : MonoBehaviour
{

    public GameObject snailStart;
    public GameObject snail1;
    


    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameObject.GetComponent<SpeechTrigger>().sentenceCount == 1)
        {
            gameObject.GetComponent<Animator>().Play("FirstMove");
            Debug.Log("This may need to change to update");
        }
    }


    void SpawnNext()
    {
        snailStart.SetActive(false);
        FindObjectOfType<TutorialCont>().u = 1;
    }

}

