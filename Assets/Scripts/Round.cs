using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    private Animator roundAnim;
    private GameObject gameController;

    private float roundStartTime;
    private float timeForOneRound = 10.0f;

    private float roundStartAnimTime;
    private float timeForTxtRound = 1.0f;

    private int roundNumber = 2;
    public void Start()
    {
        roundAnim = gameObject.GetComponent<Animator>();
        roundStartTime = Time.time;
        IsStart(false);
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        ShowRoundAnim();
        TurnOffRoundAnim();
    }

    public void IsStart(bool isStart)
    {
        roundAnim.SetBool("isStart", isStart);
    }

    public void UpdateRoundStartTime()
    {
        roundStartTime = Time.time;
    }

    public void ShowRoundAnim()
    {
        if(Time.time >= roundStartTime + timeForOneRound)
        {
            IsStart(true);
            UpdateRoundStartTime();
            roundStartAnimTime = Time.time;
        }
    }

    public void TurnOffRoundAnim()
    {
        if(Time.time >= roundStartAnimTime + timeForTxtRound)
        {
            IsStart(false);
        }
        gameController.GetComponent<GameController>().txtRound.text = "Round " + roundNumber;
        roundNumber++;
    }

}
