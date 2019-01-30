using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
namespace Com.LuisPedroFonseca.ProCamera2D
{
    public class IceBossLevelCont : MonoBehaviour {



        string levelName;
        public string nameOfLevel;
        public static IceBossLevelCont bossScript;
        public GameObject player;
        public Bossmon bossMovement;
        public GameObject swordfish;
        public ManlySwordFish swordFishScript;
        public PlayableDirector timeline;
        public int currentLine;
        public int i;
        public bool timelinePlaying;

        //private void Awake()
        //{
        //    levelName = SceneManager.GetActiveScene().name;
        //    if (levelName == nameOfLevel && bossScript == null)
        //    {
        //        DontDestroyOnLoad(gameObject);
        //        bossScript = this;
        //        Debug.Log(levelName);
        //    }
        //    else if (bossScript != this)
        //    {
        //        Destroy(gameObject);
        //    }

        //}




        // Use this for initialization
        void Start() {

            StartCoroutine(BossScript());

            timeline = GetComponent<PlayableDirector>();

        }

        private void Update()
        {
            currentLine = swordFishScript.sentenceCount;
    
           if (i == 0)
            {
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            else
            {
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        IEnumerator BossScript()
        {
            
            while (currentLine != 1)
            {
                yield return null;
            }
            timeline.enabled = true;

            yield return new WaitForSeconds(5f);
            bossMovement.GetComponent<Bossmon>().enabled = true;
            yield return new WaitForSeconds(3f);
            i++;

        }

    }
}