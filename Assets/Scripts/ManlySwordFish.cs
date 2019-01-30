using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Com.LuisPedroFonseca.ProCamera2D
{

    public class ManlySwordFish : MonoBehaviour
    {


        public SpeechManager speechManager;
        public Dialogue dialogue;
        public int sentenceCount;
        void Start()
        {
            Invoke("startDia", .5f);
        }

        // Update is called once per frame
        void Update()
        {
            sentenceCount = speechManager.sentences.Count;
            //Debug.Log(sentenceCount);
        }


        void startDia()
        {
            FindObjectOfType<SpeechManager>().StartDialogue(dialogue);
        }
    }
}
