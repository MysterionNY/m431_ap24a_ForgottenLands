using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For button components

public class MainMenuController : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button exitButton;
    public GameObject mainMenuPanel; // Reference to the panel or object containing the main menu UI

    void Start()
    {
        // Assign button click listeners
        newGameButton.onClick.AddListener(OnNewGame);
        loadGameButton.onClick.AddListener(OnLoadGame);
        exitButton.onClick.AddListener(OnExit);
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene("Ingame");
    }

    IEnumerator LoadGameScene()
    {
        // Optionally, you can display a loading screen here

        // Load the scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Ingame"); // Replace "GameScene" with your scene name

        // Optionally, you can show a loading screen or progress here
        while (!asyncLoad.isDone)
        {
            // You can update a loading bar or show progress here
            yield return null; // Wait until the next frame
        }
    }

    public void OnLoadGame()
    {
        // Implement loading game functionality here if needed
        Debug.Log("Load Game clicked");
    }

    public void OnExit()
    {
        // Exit the application
        ///Application.Quit();
        // If you're running the game in the Unity editor, use this instead:
         UnityEditor.EditorApplication.isPlaying = false;
    }
}
