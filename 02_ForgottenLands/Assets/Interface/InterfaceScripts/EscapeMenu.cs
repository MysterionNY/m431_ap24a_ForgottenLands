using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escapeMenuUI; // Assign in Inspector
    private bool isPaused = false;

    void Start()
    {
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
        Time.timeScale = 1f;
        // Save game data before loading the main menu
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.SaveGameData(); // Save game data
        }
        else
        {
            Debug.LogError("GameManager not found!");
        }
        SceneManager.LoadScene("MainMenu");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
