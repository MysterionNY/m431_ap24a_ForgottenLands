using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float Playerhealth;
    public float[] Playerposition;

    public float[] EnemyPositions;  // Store all enemy positions
    public bool[] EnemyIsDead;      // Store all enemy states
    public float[] EnemyHealths;      // Store all enemy health values

    public int healthPotions;       // Store health potion count
    public int staminaPotions;      // Store stamina potion count
    public int gold;
    public float attackDamage;
    public int curAttackLvl;
    public float upgradeCost;
    public int questIndex;
    public bool[] chestOpened;
    public string currentAudioClipName;
    public float targetAudioVolume;

    public List<QuestData> quests = new List<QuestData>(); // Store quest data
    public List<QuestStepData> questStepsData = new List<QuestStepData>();

    // Stores the information in seperate values
    // Calls the classes as parameters to access the variables
    public GameData(PlayerHealth player, List<EnemyHealth> enemies, PotionManager potionManager, List<Quest> allQuests, List<Quest> activeQuests, List<Quest> completedQuests, List<Quest> turnedInQuests, CurrencyManager currencyManager, RogueAttack rogueAttack, QuestStep questStep, NPCQuestInteraction npcQuestInteraction, List<ChestInteraction> chestInteraction, AudioManager audioManager)
    {
        targetAudioVolume = audioManager.targetVolume;
        currentAudioClipName = audioManager.audioSource.clip.name;
        gold = currencyManager.gold;
        Playerhealth = player.currentHealth;
        Playerposition = new float[3];
        Playerposition[0] = player.transform.position.x;
        Playerposition[1] = player.transform.position.y;
        Playerposition[2] = player.transform.position.z;

        EnemyPositions = new float[enemies.Count * 3];
        EnemyIsDead = new bool[enemies.Count];
        EnemyHealths = new float[enemies.Count];

        chestOpened = new bool[chestInteraction.Count];

        for (int i = 0; i < enemies.Count; i++)
        {
            EnemyPositions[i * 3] = enemies[i].transform.position.x;
            EnemyPositions[i * 3 + 1] = enemies[i].transform.position.y;
            EnemyPositions[i * 3 + 2] = enemies[i].transform.position.z;

            EnemyIsDead[i] = enemies[i].isDead;
            EnemyHealths[i] = enemies[i].currentHealth;
        }

        healthPotions = potionManager.healthPotionsAvailable;
        staminaPotions = potionManager.staminaPotionsAvailable;

        attackDamage = rogueAttack.attackDamage;
        curAttackLvl = rogueAttack.currentAttackLevel;
        upgradeCost = rogueAttack.upgradeCost;

        for (int i = 0; i < chestInteraction.Count; i++)
        {
            chestOpened[i] = chestInteraction[i].chestOpened;
        }

        // Quest data
        quests = new List<QuestData>();
        questIndex = npcQuestInteraction.currentQuestIndex;
        foreach (var quest in allQuests)
        {
            quests.Add(new QuestData(quest));
        }
        foreach (var quest in activeQuests)
        {
            quests.Add(new QuestData(quest));
        }
        foreach (var quest in completedQuests)
        {
            quests.Add(new QuestData(quest));
        }
        foreach (var quest in turnedInQuests)
        {
            quests.Add(new QuestData(quest));
        }
        questStepsData = new List<QuestStepData>();
        foreach (var quest in allQuests)
        {
            quests.Add(new QuestData(quest)); // Store quest data

            foreach (var step in quest.steps)
            {
                questStepsData.Add(new QuestStepData
                {

                    questName = quest.questName,
                    stepDescription = step.stepDescription,
                    questType = step.stepType,
                    targetCount = step.targetCount,
                    currentCount = step.currentCount
                });
            }
        }

    }
}

// Stores the Quest information
// Calls the quest class to access the variables
[System.Serializable]
public class QuestData
{
    public string questName;
    public string questDescription;
    public int rewardGold;
    public bool isActive;
    public bool isCompleted;
    public bool isTurnedIn;
    public List<QuestStepData> steps;
    public QuestStepType stepType;       // Define the type of quest step

    public QuestData(Quest quest)
    {
        questName = quest.questName;
        questDescription = quest.questDescription;
        rewardGold = quest.rewardGold;
        isActive = quest.questState == QuestState.Accepted;
        isCompleted = quest.questState == QuestState.Completed;
        isTurnedIn = quest.questState == QuestState.TurnedIn;

        // Save progress for each quest step
        steps = new List<QuestStepData>();
        foreach (var step in quest.steps)
        {
            steps.Add(new QuestStepData(step, quest.questName));
        }
    }
}

// Stores the QuestStep information
// Calls the QuestStep class to access the variables
[System.Serializable]
public class QuestStepData
{
    public string questName;
    public string stepDescription;
    public int currentCount;
    public int targetCount;
    public QuestStepType questType;
    public bool isCompleted;
    public QuestStepData() { }
    public QuestStepData(QuestStep step, string questName)
    {
        this.questName = questName;
        stepDescription = step.stepDescription;
        currentCount = step.currentCount;
        targetCount = step.targetCount;
        questType = step.stepType;
    }
}

