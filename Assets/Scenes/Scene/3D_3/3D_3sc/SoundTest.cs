using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioClip[] audioClips = null;
    private AudioSource  AudioSource = null;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource= GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        SoundTest_1();
    }
    void SoundTest_1()
    {
        if (Input.GetKey(KeyCode.K))
        {
            StopAndPlay(audioClips[0]);
        }
        if (Input.GetKey(KeyCode.L))
        {
            StopAndPlay(audioClips[1]);
        }
        if (Input.GetKey(KeyCode.J))
        {

            StopAndPlay(audioClips[2]);
        }
    }
    void StopAndPlay(AudioClip clip)
    {
        AudioSource.Stop();


        AudioSource.clip = clip;

        AudioSource.Play();
    }
}
