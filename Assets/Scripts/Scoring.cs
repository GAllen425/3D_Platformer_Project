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


    
    void Start()
    {
        playerScoreText = GameObject.Find("PlayerScoreText").GetComponent<Text>();
        remainingText = GameObject.Find("RemainingText").GetComponent<Text>();
        playerScoreText.text = playerString + playerScore.ToString();
        remainingText.text = remainingString + remaining.ToString();
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
    }
}
