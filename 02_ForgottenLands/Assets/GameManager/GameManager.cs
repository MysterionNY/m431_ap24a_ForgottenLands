using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerHealth player;
    public List<EnemyHealth> enemies;
    public GameSettings gameSettings;
    public PotionManager potionManager;
    public QuestManager questManager; // Ensure this is assigned in the editor
    public CurrencyManager currencyManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        potionManager = FindObjectOfType<PotionManager>();
        enemies = new List<EnemyHealth>(FindObjectsOfType<EnemyHealth>());
        player = FindObjectOfType<PlayerHealth>();
        questManager = FindObjectOfType<QuestManager>(); // Ensure this assignment is correct
        currencyManager = FindObjectOfType<CurrencyManager>();
        Debug.Log("GameManager initialized.");
    }

    public void StartNewGame()
    {
        SaveData.DeleteSaveFile();
        player.currentHealth = gameSettings.initialPlayerHealth;
        player.transform.position = gameSettings.playerStartPosition;
        potionManager.healthPotionsAvailable = gameSettings.healthPotions;
        potionManager.staminaPotionsAvailable = gameSettings.staminaPotions;

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].currentHealth = gameSettings.enemyInitialHealths[i];
            enemies[i].transform.position = gameSettings.enemyStartPositions[i];
            enemies[i].isDead = false;
            enemies[i].gameObject.SetActive(true);
        }

        questManager.activeQuests.Clear(); // Clear active quests
        questManager.completedQuests.Clear(); // Clear completed quests
        questManager.turnedInQuests.Clear(); // Clear turned in quests

        Debug.Log("New Game started. Save file deleted, and game state reset.");
    }

    public void SaveGameData()
    {
        SaveData.SaveGameData(player, enemies, potionManager, questManager.allQuests, currencyManager);
        Debug.Log("Game data saved.");
    }

    public void LoadPlayer()
    {
        GameData data = SaveData.LoadGameData();

        if (data != null)
        {
            player.currentHealth = data.Playerhealth;
            Vector3 playerPosition = new Vector3(data.Playerposition[0], data.Playerposition[1], data.Playerposition[2]);
            player.transform.position = playerPosition;

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

            potionManager.LoadPotionData(data);
            currencyManager.LoadCurrencyManager(data);
            questManager.LoadQuestData(data.quests);

            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.LogWarning("No game data found to load.");
        }
    }
}
