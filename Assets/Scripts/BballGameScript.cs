using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Com.LuisPedroFonseca.ProCamera2D
{
    public class BballGameScript : MonoBehaviour
    {

       
        public GameObject swordFishBoy;
        public GameObject swordFishBoy1;
        public GameObject swordFishBoy2;
        public ManlySwordFish swordFishScript;
        public Transform playerpos;
        public Dialogue dialogue;
        public GameObject formation1;
        public GameObject formation2;
        public GameObject formation3;
        public GameObject formation4;
        public GameObject player;
        public bool playerStatic;
        private Rigidbody2D body;
        public int e;
        public int n;
        int i;
        public int currentline;

     
        void Start()
        {
            n = FindObjectOfType<NumberTrackerBBall>().n;
            //e = swordFishScript.sentenceCount;

        }

        // Update is called once per frame
        void Update()
        {
            
            
            e = swordFishScript.sentenceCount;
            if (i == 1)
            {
                e = 0;
            }
            
            if (e == 3)
            {
                Debug.Log("AHHHHHHH");
                StartCoroutine(FormationSpawner());

                i = 1;
            }
            
            if (playerStatic == true)
            {
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            if (n == 1)
            {
                StartCoroutine(Formation2());
                FindObjectOfType<NumberTrackerBBall>().n = 1;
            }
            if (n == 3)
            {
                StartCoroutine(Formation3());
                FindObjectOfType<NumberTrackerBBall>().n = 3;
            }
            if (n == 5)
            {
                StartCoroutine(Formation4());
                FindObjectOfType<NumberTrackerBBall>().n = 5;
            }


        }

        IEnumerator FormationSpawner()
        {
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];


            ProCamera2DShake.Instance.Shake(shakePreset);


            yield return new WaitForSeconds(2);
            ProCamera2DShake.Instance.StopShaking();
            formation1.SetActive(true);
            //player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        IEnumerator Formation2()
        {
           
            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }
            playerStatic = true;
            swordFishBoy1.GetComponent<ManlySwordFish>().enabled = true;
            


            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);  
            ProCamera2DShake.Instance.StopShaking();
            formation1.SetActive(false);
            yield return new WaitForSeconds(1f);
            formation2.SetActive(true);
            n = 2;
            playerStatic = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


        }
        IEnumerator Formation3()
        {
            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }
            //third formation speech enable
            playerStatic = true;
            swordFishBoy2.GetComponent<ManlySwordFish>().enabled = true;
           
            
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            
            yield return new WaitForSeconds(2f);
          
            ProCamera2DShake.Instance.StopShaking();
            formation2.SetActive(false);
            yield return new WaitForSeconds(1f);
          
            formation3.SetActive(true);
            n = 4;

            playerStatic = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

        IEnumerator Formation4()
        {
            while (player.transform.position.x != playerpos.transform.position.x)
            {
                player.transform.position = new Vector2(playerpos.transform.position.x, playerpos.transform.position.y);
                yield return null;

            }
            playerStatic = true;
            var shakePreset = ProCamera2DShake.Instance.ShakePresets[Random.Range(0, ProCamera2DShake.Instance.ShakePresets.Count)];
            ProCamera2DShake.Instance.Shake(shakePreset);
            yield return new WaitForSeconds(2f);
            ProCamera2DShake.Instance.StopShaking();
            formation3.SetActive(false);
            Destroy(swordFishBoy);
            Destroy(swordFishBoy1);
            Destroy(swordFishBoy2);
            yield return new WaitForSeconds(1f);
            formation4.SetActive(true);
            n = 6;
            playerStatic = false;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }




        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
               
                n++;
            }
        }

       
        

    }


    


}


