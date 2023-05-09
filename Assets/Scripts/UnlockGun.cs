using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockGun : MonoBehaviour
{
    private float startGameTime;
    private float startUnlockTime = 60.0f;
    private float stopUnlockTime = 2.0f;

    private Animator anim;

    private GameObject gameController;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        startGameTime= Time.time;
        ShowUnlockGun(false);
    }

    private void Update()
    {
        if (Time.time >= startGameTime + startUnlockTime && Time.time <= stopUnlockTime + startUnlockTime)
        {
            ShowUnlockGun(true);
        }
        else
        {
            ShowUnlockGun(false);
        }
    }

    private void ShowUnlockGun(bool isStart)
    {
        anim.SetBool("isStart", isStart);
    }


}
