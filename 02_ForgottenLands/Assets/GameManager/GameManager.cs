using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public PlayerHealth player;
    public List<EnemyHealth> enemies;
    public GameSettings gameSettings;
    public PotionManager potionManager;
    public QuestManager questManager;
    public List<ChestInteraction> chestInteraction;
    public CurrencyManager currencyManager;
    public RogueAttack rogueAttack;
    public Quest quest;
    public QuestStep questSteps;
    public NPCQuestInteraction npcQuestInteraction;
    public AudioManager audioManager;

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

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        potionManager = FindObjectOfType<PotionManager>();
        enemies = new List<EnemyHealth>(FindObjectsOfType<EnemyHealth>());
        player = FindObjectOfType<PlayerHealth>();
        questManager = FindObjectOfType<QuestManager>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        rogueAttack = FindObjectOfType<RogueAttack>();
        npcQuestInteraction = FindObjectOfType<NPCQuestInteraction>();
        chestInteraction = new List<ChestInteraction>(FindObjectsOfType<ChestInteraction>());
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Deletes savefiles and creates a new instance of the game
    public void StartNewGame()
    {
        SaveData.DeleteSaveFile();
        Debug.Log("New Game started. Save file deleted, and game state reset.");
    }

    // Saves the games information
    public void SaveGameData()
    {
        SaveData.SaveGameData(player, enemies, potionManager, questManager.allQuests, questManager.activeQuests, questManager.completedQuests, questManager.turnedInQuests, currencyManager, rogueAttack, questSteps, npcQuestInteraction, chestInteraction, audioManager);
        Debug.Log("Game data saved.");
    }

    // Loads the game information and passes them back to the classes variables
    public void LoadPlayer()
    {
        GameData data = SaveData.LoadGameData();

        if (data != null)
        {
            AudioClip loadedClip = Resources.Load<AudioClip>("SFX/" + data.currentAudioClipName);
            audioManager.audioSource.clip = loadedClip;
            audioManager.audioSource.Play();
            audioManager.targetVolume = data.targetAudioVolume;
            audioManager.audioSource.volume = data.targetAudioVolume;
            audioManager.audioSource.loop = true;
            Debug.LogError("Failed to load audio clip: " + data.currentAudioClipName);
            Debug.LogError("Failed to load audio clip: " + loadedClip);
            player.currentHealth = data.Playerhealth;
            Vector3 playerPosition = new Vector3(data.Playerposition[0], data.Playerposition[1], data.Playerposition[2]);
            player.transform.position = playerPosition;

            for (int i = 0; i < enemies.Count; i++)
            {
                //Vector3 enemyPosition = new Vector3(data.EnemyPositions[i * 3], data.EnemyPositions[i * 3 + 1], data.EnemyPositions[i * 3 + 2]);
                //enemies[i].transform.position = enemyPosition;
                //enemies[i].currentHealth = data.EnemyHealths[i];
                enemies[i].isDead = data.EnemyIsDead[i];

                if (enemies[i].isDead)
                {
                    enemies[i].gameObject.SetActive(false);
                }
            }

            potionManager.LoadPotionData(data);
            currencyManager.LoadCurrencyManager(data);
            rogueAttack.LoadAttackData(data);
            npcQuestInteraction.currentQuestIndex = data.questIndex;
            questManager.LoadQuestData(data.quests, data.questStepsData);
            

            for (int i = 0; i < chestInteraction.Count; i++)
            {
                chestInteraction[i].chestOpened = data.chestOpened[i];
            }

            Debug.Log("Game data loaded.");
        }
        else
        {
            Debug.LogWarning("No game data found to load.");
        }
    }
}
