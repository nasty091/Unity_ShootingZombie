using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUnlockGunSound : MonoBehaviour
{
    private AudioSource unlockGunSound;

    private void Start()
    {
        unlockGunSound = gameObject.GetComponent<AudioSource>();
    }

    public void UnlockGunPlay()
    {
        unlockGunSound.Play();
    }
}
