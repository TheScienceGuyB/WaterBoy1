
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour {


    public Animator animator;
    public string LevelToLoad;
    public string levelname;
    LevelManager levelMan;




    //private void OnEnable()
    //{
    //    Debug.Log("OnEnableCalled");
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    LevelManager.control.Save();
    //    Debug.Log(levelname);
    //}
    // Update is called once per frame
    void Update () {
        
    }

    public void FadeToLevel(string name)
    {
        LevelToLoad = name;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeToLevel(levelname);
    }


    //private void OnDisable()
    //{
    //    SceneManager.sceneLoaded -= OnSceneLoaded;
    //}

}
