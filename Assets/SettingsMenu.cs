using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource sounds;
    public AudioSource music;
    public GameObject soundsb;
    public GameObject musicb;
    public GameObject vhsb;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Sound")) if (PlayerPrefs.GetInt("Sound") == 1) Sound(true); else Sound(false);
        if (PlayerPrefs.HasKey("Music")) if (PlayerPrefs.GetInt("Music") == 1) Music(true); else Music(false);
        if (PlayerPrefs.HasKey("VHS")) if (PlayerPrefs.GetInt("VHS") == 1) VHS(true); else VHS(false);

    }
    public void Sound(bool on)
    {
        PlayerPrefs.SetInt("Sound", on ? 1 : 0);
        sounds.enabled= on;
        soundsb.SetActive(on);
    }
    public void Music(bool on)
    {
        PlayerPrefs.SetInt("Music", on ? 1 : 0);
        music.enabled= on;
        musicb.SetActive(on);
    }    
    public void VHS(bool on)
    {
        PlayerPrefs.SetInt("VHS", on ? 1 : 0);
        Camera.main.GetComponent<PostProcessLayer>().enabled= on;
        Camera.main.GetComponent<BrewedInk.CRT.CRTCameraBehaviour>().enabled= on;
        vhsb.SetActive(on);
    }

}
