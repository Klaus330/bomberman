using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;

    void Start()
    {
        volumeSlider = gameObject.GetComponent<Slider>();
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.3f);
        }
        Load();
    }

    public void ChangeVolume()
    {
        FindObjectOfType<AudioManager>().SetVolume("BackgroundMusic", volumeSlider.value);
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
