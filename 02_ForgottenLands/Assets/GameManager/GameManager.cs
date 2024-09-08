using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerHealth player; // Assign this in the Unity editor
    public List<EnemyHealth> enemies; // Assign this in the Unity editor
    public GameSettings gameSettings; // Assign this in the Unity editor
    public PotionManager potionManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        potionManager = FindObjectOfType<PotionManager>();
        enemies = new List<EnemyHealth>(FindObjectsOfType<EnemyHealth>());
        player = FindObjectOfType<PlayerHealth>();
        Debug.Log("GameManager initialized.");
    }

    public void StartNewGame()
    {
        // Delete any existing save file
        SaveData.DeleteSaveFile();

        // Reset player health and position
        player.currentHealth = gameSettings.initialPlayerHealth; // If you're using GameSettings for health as well
        player.transform.position = gameSettings.playerStartPosition;

        potionManager.healthPotionsAvailable = gameSettings.healthPotions;
        potionManager.staminaPotionsAvailable = gameSettings.staminaPotions;

        // Reset enemies' health, position, and active state
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].currentHealth = gameSettings.enemyInitialHealths[i]; // Assuming you've added health to GameSettings
            enemies[i].transform.position = gameSettings.enemyStartPositions[i];
            enemies[i].isDead = false;
            enemies[i].gameObject.SetActive(true); // Reactivate the enemy if it was previously disabled
        }

        Debug.Log("New Game started. Save file deleted, and game state reset.");
    }


    public void SaveGameData()
    {
        SaveData.SaveGameData(player, enemies, potionManager);
    }

    public void LoadPlayer()
    {
        GameData data = SaveData.LoadGameData();

        if (data != null)
        {
            // Load player data
            player.currentHealth = data.Playerhealth;
            Vector3 playerPosition = new Vector3(data.Playerposition[0], data.Playerposition[1], data.Playerposition[2]);
            player.transform.position = playerPosition;

            // Load enemy data
            for (int i = 0; i < enemies.Count; i++)
            {
                Vector3 enemyPosition = new Vector3(data.EnemyPositions[i * 3], data.EnemyPositions[i * 3 + 1], data.EnemyPositions[i * 3 + 2]);
                enemies[i].transform.position = enemyPosition;
                enemies[i].currentHealth = data.EnemyHealths[i];
                enemies[i].isDead = data.EnemyIsDead[i];

                if (enemies[i].isDead)
                {
                    enemies[i].gameObject.SetActive(false);
                }
            }

            // Load potions
            potionManager.LoadPotionData(data);
        }
    }
}
