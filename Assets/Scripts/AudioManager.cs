using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sounds[] sounds;
    public static AudioManager instance;

	// Use this for initialization
	void Awake () {
        
        if (instance == null)
        
            instance = this;
        
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }
	}

    private void Start()
    {
        Play("Theme");
    }

    public void Play (string name)
    {
      Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "Not found");
            return;
            
        }
            
        s.source.Play();
    }



    public void Stop (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();

    }
}



