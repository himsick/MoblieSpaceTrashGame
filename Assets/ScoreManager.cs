using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int initialScore = 0;

    void Awake()
    {
        Instance = this;
        ResetScore(); // Set initial score on Awake
    }

    private int score = 0;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    public void DecreaseScore(int value)
    {
        score -= value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ResetScore()
    {
        score = initialScore;
        UpdateScoreUI();
    }
}