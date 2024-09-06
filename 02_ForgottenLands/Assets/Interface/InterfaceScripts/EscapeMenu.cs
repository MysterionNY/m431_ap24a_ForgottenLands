using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuUI; // Assign in Inspector
    private bool isPaused = false;

    void Start()
    {
        // Ensure escape menu is hidden initially
        escapeMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        escapeMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void Pause()
    {
        escapeMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game is unpaused
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to your main menu scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
