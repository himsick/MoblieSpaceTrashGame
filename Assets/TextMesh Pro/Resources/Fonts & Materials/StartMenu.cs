using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        // Assuming PauseMenu is attached to the same GameObject as this script
        PauseMenu pauseMenu = GetComponent<PauseMenu>();

        if (pauseMenu != null)
        {
            pauseMenu.ResumeGame(); // Call the ResumeGame method to unpause the game
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
