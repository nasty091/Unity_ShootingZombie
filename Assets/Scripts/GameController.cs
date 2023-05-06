using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public Text txtPoint;
 
    internal int currentPoint = 0;

    public Text txtRound;

    private float startRound2Time;

    //[SerializeField]
    //private float roundTime = 40.0f;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1;
        menu.SetActive(false);
        //txtRound.enabled = false;
        //startRound2Time = Time.time;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Time.time >= startRound2Time + roundTime)
    //    {
    //        txtRound.enabled = true;
    //        Destroy(txtRound, 2.0f);   
    //    }
    //}


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
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void EndGame()
    {
        StartCoroutine(DieDelay());
    }
}
