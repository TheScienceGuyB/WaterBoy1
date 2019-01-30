using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Com.LuisPedroFonseca.ProCamera2D
{
    public class NumberTrackerBBall : MonoBehaviour
    {




        string levelName;
        public string nameOfBBallLevel;
        public static NumberTrackerBBall numberTracker;


        public int n;


        private void Awake()
        {
            levelName = SceneManager.GetActiveScene().name;
            if (levelName == nameOfBBallLevel && numberTracker == null)
            {
                DontDestroyOnLoad(gameObject);
                numberTracker = this;

            }
            else if (numberTracker != this)
            {
                Destroy(gameObject);
            }

            

        }




        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (n == 5)
            {
                Destroy(GameObject.Find("SwordFishDialogue"));
            }
        }
    }
}