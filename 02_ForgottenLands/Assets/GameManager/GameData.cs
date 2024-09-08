using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int Playerhealth;
    public float[] Playerposition;

    public float[] EnemyPositions;  // Store all enemy positions
    public bool[] EnemyIsDead;      // Store all enemy states
    public int[] EnemyHealths;      // Store all enemy health values

    public int healthPotions;       // Store health potion count
    public int staminaPotions;      // Store stamina potion count
    public int gold;

    public List<QuestData> quests = new List<QuestData>(); // Store quest data

    public GameData(PlayerHealth player, List<EnemyHealth> enemies, PotionManager potionManager, List<Quest> activeQuests, CurrencyManager currencyManager)
    {
        gold = currencyManager.gold;
        Playerhealth = player.currentHealth;
        Playerposition = new float[3];
        Playerposition[0] = player.transform.position.x;
        Playerposition[1] = player.transform.position.y;
        Playerposition[2] = player.transform.position.z;

        EnemyPositions = new float[enemies.Count * 3];
        EnemyIsDead = new bool[enemies.Count];
        EnemyHealths = new int[enemies.Count];

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

        // Quest data
        quests = new List<QuestData>();
        foreach (var quest in activeQuests)
        {
            quests.Add(new QuestData(quest));
        }
    }
}

[System.Serializable]
public class QuestData
{
    public string questName;
    public bool isActive;
    public bool isCompleted;
    public bool isTurnedIn;
    public List<QuestStepData> steps;

    public QuestData(Quest quest)
    {
        questName = quest.questName;
        isActive = quest.questState == QuestState.InProgress || quest.questState == QuestState.Accepted;
        isCompleted = quest.questState == QuestState.Completed;
        isTurnedIn = quest.questState == QuestState.TurnedIn;

        // Save progress for each quest step
        steps = new List<QuestStepData>();
        foreach (var step in quest.steps)
        {
            steps.Add(new QuestStepData(step));
        }
    }
}

[System.Serializable]
public class QuestStepData
{
    public string stepDescription;
    public int currentCount;  // Track how many of the target have been completed
    public int targetCount;

    public QuestStepData(QuestStep step)
    {
        stepDescription = step.stepDescription;
        currentCount = step.currentCount;
        targetCount = step.targetCount;
    }
}

