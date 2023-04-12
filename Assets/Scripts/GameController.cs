using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject menu;
    public Text txtPoint;

    private int currentPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
