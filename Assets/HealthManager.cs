// HealthManager.cs
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public TextMeshProUGUI healthText;
    private int health = 100; // Declare the 'health' variable here

    void Awake()
    {
        Instance = this;
        ResetHealth(); // Set initial health on Awake
    }

    // Updated DecreaseHealth method with a parameter for the decrease value
    public void DecreaseHealth(int decreaseValue)
    {
        health -= decreaseValue; // Adjust this based on your game design
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercentage()
    {
        return (float)health / 100f;
    }

    public void ResetHealth()
    {
        health = 100; // Reset to the initial health value
        UpdateHealthUI();
    }
}
