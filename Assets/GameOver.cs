using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor by default
        Cursor.visible = false; // Make cursor invisible by default
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
   void Update()
    {
        // Check if health is 0
        if (HealthManager.Instance.GetHealth() <= 0)
        {
            if (!isPaused)
            {
                PauseGame();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Unlock cursor when paused
        Cursor.visible = true; // Make cursor visible when paused
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Set time scale back to 1 to resume the game
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor when resumed
        Cursor.visible = false; // Make cursor invisible when resumed
    }
    
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Start Screen");

    }
}
