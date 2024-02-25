using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI healthText;
    public Slider healthBar;
    public TextMeshProUGUI timeLeftText;
    public Button restartButton;

    public ScoreManager scoreManager;
    public HealthManager healthManager;
    
    void Start()
    {
        scoreManager = ScoreManager.Instance;
        healthManager = HealthManager.Instance;

        // Initialize the UI state
        UpdateUI();
    }

    void Update()
    {
        // Check for game over condition

        // Update UI elements with current game state
        UpdateUI();
    }

    void UpdateUI()
    {
        UpdateScoreUI();
        UpdateHealthUI();
        UpdateTimeLeftUI();
        UpdateFinalScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null && scoreManager != null)
        {
            scoreText.text = "Score: " + scoreManager.Score;
        }
        else
        {
            Debug.LogError("scoreText or scoreManager is null.");
        }
    }
        void UpdateFinalScoreUI()
    {
        if (finalText != null && scoreManager != null)
        {
            finalText.text = scoreManager.Score + " Points";
        }
        else
        {
            Debug.LogError("scoreText or scoreManager is null.");
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null && healthBar != null && healthManager != null)
        {
            healthText.text = "Health: " + healthManager.GetHealth();
            healthBar.value = healthManager.GetHealthPercentage();
        }
        else
        {
            Debug.LogError("healthText, healthBar, or healthManager is null.");
        }
    }

    void UpdateTimeLeftUI()
    {
        if (timeLeftText != null)
        {
            // Calculate time left from the starting value of 120
            float timeLeft = 120 - Time.time;

            // Display the time left
            timeLeftText.text = "Time Left: " + Mathf.Round(timeLeft);
        }
        else
        {
            Debug.LogError("timeLeftText is null.");
        }
    }

    // Handle any additional UI updates or interactions here
}
