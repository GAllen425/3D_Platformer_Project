using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;
    public GameObject endGameSplash = null;
    
    public bool playerActive = false;
    public bool gameOver = false;
    public bool gameStarted = false;
    public bool gameEnded = false;

    public Text timeLeftText;
    public Text countdownText;
    public int timeLeft = 60;
    public int countdown = 3;
    public bool countdownActive;
    void Awake()
    {
        countdownText = GameObject.FindGameObjectWithTag("countdownText").GetComponent<Text>();
        timeLeftText = GameObject.FindGameObjectWithTag("timeLeftText").GetComponent<Text>();
        endGameSplash = GameObject.FindGameObjectWithTag("gameOver");
        endGameSplash.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timeLeftText.text = "";
        countdownActive = true;
        StartCoroutine("StartCountdown");
    }

    void Update ()
    {
        if (countdownActive)
        {
            countdownText.text = countdown.ToString();

            if (countdown <= 0)
            {
                countdownActive = false;
                countdownText.text = "";
                PlayerStartedGame();
            }
        }

        timeLeftText.text = timeLeft.ToString();

        // Game can be over by timer or by all the acorns being picked up
        if (timeLeft <= 0 || gameOver)
        {
            timeLeftText.text = "";
            this.EndGame();
        }
    }

    public void EndGame()
    {
        gameOver = true;
        playerActive = false;
        endGameSplash.SetActive(true);
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
        StartCoroutine("LoseTime");
        Time.timeScale = 1.0f;
        endGameSplash.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator StartCountdown()
    {
        Time.timeScale = 1.0f;
        while (countdown > 0) {
            yield return new WaitForSeconds(1);
            countdown--;
        }
    }

    IEnumerator LoseTime()
    {
        Time.timeScale = 1.0f;
        while (timeLeft > 0) {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
