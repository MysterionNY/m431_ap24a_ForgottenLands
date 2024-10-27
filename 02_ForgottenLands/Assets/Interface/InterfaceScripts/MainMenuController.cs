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

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        newGameButton.onClick.AddListener(OnNewGame);
        loadGameButton.onClick.AddListener(OnLoadGame);
        exitButton.onClick.AddListener(OnExit);
        controlsUI.SetActive(false);

        SceneManager.sceneLoaded += OnSceneLoaded;
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
        }
    }

    // Loads the scene "Ingame" when called
    // Parameters define what scene to load
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

    // Deletes existing savefile to create a new game instance when called and starts with a cutscene scene
    public void OnNewGame()
    {
        SaveData.DeleteSaveFile();
        SceneManager.LoadScene("EnteringTheVillageCS");
    }

    // Loads back into ingame when called
    public void OnLoadGame()
    {
        SceneManager.LoadScene("Ingame");
    }

    // Shows Controls panel when called
    public void Controls()
    {
        controlsUI.SetActive(true);     // Show the controls image
        showingControls = true;         // Mark that we are on the Controls screen
    }

    // Returns back to menu when called
    public void BackToMenu()
    {
        controlsUI.SetActive(false);   // Hide controls image
        showingControls = false;       // No longer in Controls screen
    }

    // Quits out the game when called
    public void OnExit()
    {
        Application.Quit();
    }
}
