using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRoundSound : MonoBehaviour
{
    private AudioSource roundSound;

    private void Start()
    {
        roundSound = gameObject.GetComponent<AudioSource>();
    }

    public void Play()
    {
        roundSound.Play();
    }
}
