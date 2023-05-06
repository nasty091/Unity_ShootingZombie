using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    private Animator anim;
    private float startGameTime;
    [SerializeField]
    private float startRoundTime = 40.0f;
    [SerializeField]
    private float stopRoundTime = 42.0f;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        startGameTime = Time.time;
        ShowRound(false);
    }

    private void Update()
    {
        if(Time.time >= startGameTime + startRoundTime && Time.time <= startGameTime + stopRoundTime)
        {
            ShowRound(true);
        }
        else
        {
            ShowRound(false);
        }
    }

    private void ShowRound(bool isStart)
    {
        anim.SetBool("isStart", isStart);
    }
}
