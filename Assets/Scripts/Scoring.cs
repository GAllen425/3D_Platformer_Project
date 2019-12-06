using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public int playerScore = 0;
    public Text playerScoreText;

    public int remaining = 0;
    public Text remainingText;
    string remainingString = "Remaining: ";
    string playerString = "Score: ";
    
    void Awake()
    {
        Debug.Log("Started");
        playerScoreText = GameObject.FindGameObjectWithTag("PlayerScoreText").GetComponent<Text>();
        remainingText = GameObject.FindGameObjectWithTag("RemainingText").GetComponent<Text>();
        
        if (playerScoreText != null && remainingText != null)
        {
            playerScoreText.text = playerString + playerScore.ToString();
            remainingText.text = remainingString + remaining.ToString();
        }
        else
        {
            Debug.Log("playerScoreText or remainingText is null");
        }
    }

    public void AddPlayerScore()
    {
        playerScore++;
        playerScoreText.text = playerString + playerScore.ToString();
    }
    
    public void AddRemainingScore()
    {
        remaining++;
        remainingText.text = remainingString + remaining.ToString();
    }

    public void RemoveRemainingScore()
    {
        remaining--;
        remainingText.text = remainingString + remaining.ToString();

        if (GameManager.instance.playerActive && remaining == 0)
        {
            GameManager.instance.EndGame();
        }
    }
}
