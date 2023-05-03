using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSoundEffect : MonoBehaviour
{
    private AudioSource roundSound;
    //public AudioClip roundSoundClip;
    private float startGameTime;
    private float startSoundEffectTime = 2.5f;

    private void Start()
    {
        startGameTime = Time.time;
        roundSound = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Time.time >= startGameTime + startSoundEffectTime)
        {
            roundSound.Play();
        }
    }
}
