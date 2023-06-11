using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    int playerScore = 0;

    public void AddScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void PlayerDied()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }
}