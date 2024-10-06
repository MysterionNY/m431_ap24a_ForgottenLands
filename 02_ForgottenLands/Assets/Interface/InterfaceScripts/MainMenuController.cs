using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitButton;
    public GameObject controlsUI;
    private bool showingControls = false;

    void Start()
    {
        newGameButton.onClick.AddListener(OnNewGame);
        loadGameButton.onClick.AddListener(OnLoadGame);
        exitButton.onClick.AddListener(OnExit);
        controlsUI.SetActive(false);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showingControls)
            {
                BackToMenu(); // Return from Controls screen
            }
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Ingame")
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.LoadPlayer(); // Load game data
            }
            else
            {
                Debug.LogError("GameManager not found in the scene!");
            }
        }
    }

    public void OnNewGame()
    {
        SaveData.DeleteSaveFile();
        SceneManager.LoadScene("Ingame");
    }

    public void OnLoadGame()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void Controls()
    {
        controlsUI.SetActive(true);     // Show the controls image
        showingControls = true;         // Mark that we are on the Controls screen
    }

    public void BackToMenu()
    {
        controlsUI.SetActive(false);   // Hide controls image
        showingControls = false;       // No longer in Controls screen
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
