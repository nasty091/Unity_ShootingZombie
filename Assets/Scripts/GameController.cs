using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public Text txtPoint;
 
    internal int currentPoint = 0;

    public Text txtRound;
    private int roundNumber = 2;

    private float roundStartTime;
    private float roundTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1;
        menu.SetActive(false);
        txtRound.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoint == 2)
        {
            txtRound.text = "ROUND " + roundNumber;
            roundNumber++;
            txtRound.enabled = true;
            roundStartTime = Time.time;
        }

        if(Time.time > roundStartTime + roundTime) 
        {
            txtRound.enabled = false;
        }
    }

    public void GetPoint(int point)
    {
        currentPoint++;
        txtPoint.text = "Zombie killed: " + currentPoint.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void EndGame()
    {
        StartCoroutine(DieDelay());
    }
}
