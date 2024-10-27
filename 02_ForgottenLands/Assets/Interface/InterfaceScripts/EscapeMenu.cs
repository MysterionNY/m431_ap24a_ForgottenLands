using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuUI; // Assign in Inspector
    public GameObject controlsUI;
    private bool isPaused = false;
    private bool showingControls = false;

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        escapeMenuUI.SetActive(false);
        controlsUI.SetActive(false);
    }

    // Updates on every call
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

    // When called, it will deactivate the panel
    public void Resume()
    {
        escapeMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    // When called it will pause the game
    public void Pause()
    {
        escapeMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
    }

    // When called it will showcase controls panel
    public void Controls()
    {
        escapeMenuUI.SetActive(false);  // Hide the escape menu UI
        controlsUI.SetActive(true);     // Show the controls image
        showingControls = true;         // Mark that we are on the Controls screen
    }

    // When called it will return back to menu
    public void BackToMenu()
    {
        controlsUI.SetActive(false);   // Hide controls image
        escapeMenuUI.SetActive(true);  // Return to the escape menu UI
        showingControls = false;       // No longer in Controls screen
    }

    // When called it will return back to main menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
