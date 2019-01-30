using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Com.LuisPedroFonseca.ProCamera2D
{





    public class BballLevelScriptEnd : MonoBehaviour
    {

        public GameObject blackPanel;
        public GameObject player;
        public GameObject swordfish;
        public ManlySwordFish swordFishScript;
        public GameObject iceBreak;
        public Dialogue dialogue;
        public SpeechManager speechManager;
        public Animator pedastal;
        public int currentLine;
        public int i;
       


        // Use this for initialization
        void Start()
        {
            swordfish.GetComponent<ManlySwordFish>().enabled = true;
            gameObject.GetComponent<BballLevelScriptEnd>().enabled = (false);
        }

        // Update is called once per frame
        void Update()
        {
            player.GetComponent<PlayerUI>().enabled = false;

            currentLine = swordFishScript.sentenceCount;
            if (i == 1)
            {
                StartCoroutine(loadScence());
            }
    
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {

                gameObject.GetComponent<BballLevelScriptEnd>().enabled = (true);

                StartCoroutine(TrophyCoroutine());
            }

        }



        IEnumerator TrophyCoroutine()
        {
        
            yield return new WaitForSeconds(2f);

            
            Destroy(blackPanel);

            while (speechManager.dialogueActive != false)
            {

                yield return null;
                
            }
            
           
            yield return StartCoroutine(TrophyFall());

            
           // yield return StartCoroutine(loadScence());
       
  
        }
        IEnumerator TrophyFall()
        {
            var shakePreset1 = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset1);
            yield return new WaitForSeconds(1);
            ProCamera2DShake.Instance.StopShaking();
            pedastal.Play("TrophyFallG");
            yield return new WaitForSeconds(2.5f);
            
            pedastal.Play("SquishG");
            yield return new WaitForSeconds(2.5f);
            
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);
            
            i++;

        }
        IEnumerator loadScence()
        {
            Destroy(iceBreak);
            pedastal.Play("fallingPedastalG");
            yield return null;
            i++;
        }


        



        
       
    }






}
   
