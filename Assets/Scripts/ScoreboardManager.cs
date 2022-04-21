using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    public static ScoreboardManager manager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    int score = 0;
    int lives = 3;

    private void Awake()
    {
        manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void setScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + score.ToString();
    }

    public void setLives()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
    }

    public void resetLives()
    {
        lives = 3;
        livesText.text = "Lives: " + lives.ToString();
    }
}
