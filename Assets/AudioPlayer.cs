using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource audio;
    public float kd=0.3f;
    float t;
    void Start()
    {
        audio=Camera.main.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (t < kd) t += Time.deltaTime;
    }
    // Update is called once per frame
    public void Play()
    {
        if (t >= kd)
        {
            audio.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
            t = 0;
        }
    }
    public void Play(int i)
    {
        if (t >= kd)
        {
            audio.PlayOneShot(sounds[i]);
            t = 0;
        }
    }
}
