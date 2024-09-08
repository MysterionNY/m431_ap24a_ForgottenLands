using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitButton;

    void Start()
    {
        newGameButton.onClick.AddListener(OnNewGame);
        loadGameButton.onClick.AddListener(OnLoadGame);
        exitButton.onClick.AddListener(OnExit);

        SceneManager.sceneLoaded += OnSceneLoaded;
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

    public void OnExit()
    {
        Application.Quit();
    }
}
