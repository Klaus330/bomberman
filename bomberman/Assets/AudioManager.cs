using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public Sound[] soundsList; 

    public static AudioManager instance;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound sound in soundsList)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(soundsList, sound => sound.name == name);
        
        if (sound == null) {
            Debug.LogWarning("Sound: " + name +" not found.");
            return;
        }

        sound.source.Play();
    }

    void Start()
    {
        Sound sound = Array.Find(soundsList, sound => sound.name == "BackgroundMusic");
        sound.source.volume = volumeSlider.value;
        Play("BackgroundMusic");
    }

    public void SetVolume(string name, float volume)
    {
        Sound sound = Array.Find(soundsList, sound => sound.name == name);
        sound.source.volume = volume;
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(soundsList, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        sound.source.Stop();
    }

}
