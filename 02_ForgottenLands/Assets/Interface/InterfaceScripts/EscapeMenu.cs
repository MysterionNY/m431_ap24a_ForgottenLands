using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuUI; // Assign in Inspector
    public GameObject controlsUI;
    private bool isPaused = false;
    private bool showingControls = false;

    void Start()
    {
        escapeMenuUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showingControls)
            {
                BackToMenu(); // Return from Controls screen
            }
            else if (isPaused)
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

    public void Controls()
    {
        escapeMenuUI.SetActive(false);  // Hide the escape menu UI
        controlsUI.SetActive(true);     // Show the controls image
        showingControls = true;         // Mark that we are on the Controls screen
    }

    public void BackToMenu()
    {
        controlsUI.SetActive(false);   // Hide controls image
        escapeMenuUI.SetActive(true);  // Return to the escape menu UI
        showingControls = false;       // No longer in Controls screen
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
