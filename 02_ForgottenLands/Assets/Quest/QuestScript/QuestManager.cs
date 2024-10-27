using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    public List<Quest> allQuests = new List<Quest>();

    [SerializeField]
    public List<Quest> activeQuests = new List<Quest>();

    [SerializeField]
    public List<Quest> completedQuests = new List<Quest>();

    [SerializeField]
    public List<Quest> turnedInQuests = new List<Quest>();

    public QuestLog questLog;
    public CurrencyManager currencyManager;
    public static QuestManager instance;


    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance and mark this GameObject to persist across scenes
        instance = this;
    }

    public Quest CreateQuestInstance(Quest quest)
    {
        return Instantiate(quest);  // Creates a runtime copy
    }

    // Checks if the enemy was killed when quest is active
    // Parameter checks for the enemy type (Goblin, Boss etc)
    public void EnemyKilled(string enemyType)
    {
        // Temporary list to store quests that need to be processed
        List<Quest> questsToComplete = new List<Quest>();

        // Iterate through the active quests
        if(enemyType == "Enemy")
        {
            foreach (var quest in activeQuests)
            {
                foreach (var step in quest.steps)
                {
                    if (step.stepType == QuestStepType.KillEnemies && !step.isCompleted)
                    {
                        step.IncrementCount();

                        // Check if all steps of the quest are completed
                        if (quest.CheckCompletion())
                        {
                            questsToComplete.Add(quest);
                        }
                    }
                }
            }
        }

        if(enemyType == "Boss")
        {
            foreach (var quest in activeQuests)
            {
                foreach (var step in quest.steps)
                {
                    if (step.stepType == QuestStepType.KillBoss && !step.isCompleted)
                    {
                        step.IncrementCount();

                        // Check if all steps of the quest are completed
                        if (quest.CheckCompletion())
                        {
                            questsToComplete.Add(quest);
                        }
                    }
                }
            }
        }
        
        // Process completed quests after the iteration
        foreach (var quest in questsToComplete)
        {
            CompleteQuest(quest);
            Debug.Log("Quest Completed: " + quest.questName);
        }
    }

    // Checks if the quest is active
    // Parameter checks if the quest name matches to know where to assign it to
    public void ItemCollected(string questName)
    {
        List<Quest> questsToComplete = new List<Quest>();

        // Iterate through active quests and check their steps
        foreach (var quest in activeQuests)
        {
            if (quest.questName == questName)  // Match the overall quest name
            {
                foreach (var step in quest.steps)
                {
                    // Check if the quest step is about collecting items and if it's incomplete
                    if (step.stepType == QuestStepType.CollectItems && !step.isCompleted)
                    {
                        step.IncrementCount();  // Increment the count for collected items

                        // Check if the whole quest is completed
                        if (quest.CheckCompletion())
                        {
                            questsToComplete.Add(quest);  // Add the quest to the completion list
                        }
                    }
                }
            }
        }

        // Complete quests that are finished
        foreach (var quest in questsToComplete)
        {
            CompleteQuest(quest);
            Debug.Log("Quest Completed: " + quest.questName);
        }

        // Update the quest log UI after collection
        questLog.UpdateQuestLogUI();
    }

    // Accepts Quest
    // Parameter checks if the list of quest states already contain that quest
    public void AcceptQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest) && !completedQuests.Contains(quest) && !turnedInQuests.Contains(quest))
        {
            quest.questState = QuestState.Accepted;
            activeQuests.Add(quest);
            questLog.UpdateQuestLogUI();
            UpdateNPCQuestIndicator(quest);
        }
    }

    // Complete Quest
    // Parameter checks if the list of quest states already contain that quest
    public void CompleteQuest(Quest quest)
    {
        if (quest.CheckCompletion())
        {
            quest.questState = QuestState.Completed;
            activeQuests.Remove(quest);
            completedQuests.Add(quest);

            questLog.UpdateQuestLogUI();
            UpdateNPCQuestIndicator(quest);
        }
    }

    // Turn in quest
    // Parameter checks if the list of quest states already contain that quest
    public void TurnInQuest(Quest quest)
    {
        if (quest.questState == QuestState.Completed)
        {
            quest.questState = QuestState.TurnedIn;
            RewardPlayer(quest.rewardGold);
            completedQuests.Remove(quest);
            turnedInQuests.Add(quest);
            questLog.UpdateQuestLogUI();
            UpdateNPCQuestIndicator(quest);
        }
    }

    // Update Quest Indicator
    // Checks for the available quests the NPC has by calling the FindNPCByQuest function
    void UpdateNPCQuestIndicator(Quest quest)
    {
        NPCQuestInteraction npc = FindNPCByQuest(quest.questName);

        if (npc != null)
        {
            npc.UpdateQuestIndicator();
        }
    }

    // Checks for the assigned quests to an NPC
    // Parameter checks if the questname matches
    NPCQuestInteraction FindNPCByQuest(string questName)
    {
        NPCQuestInteraction[] npcs = FindObjectsOfType<NPCQuestInteraction>();
        foreach (var npc in npcs)
        {
            if (npc.assignedQuests.Exists(q => q.questName == questName))
            {
                return npc;
            }
        }
        return null;
    }

    // When a quest was solved, give the player gold, by calling the add gold function
    void RewardPlayer(int goldAmount)
    {
        currencyManager.AddGold(goldAmount);
    }

    // Gets the quest by checking their name
    // Parameter checks if any of the quest states match up the quest name
    // Returns the current quest
    public Quest GetQuestByName(string questName)
    {
        Debug.Log($"Searching for quest: {questName}");

        Quest quest = activeQuests.Find(q => q.questName == questName);
        if (quest == null)
        {
            quest = completedQuests.Find(q => q.questName == questName);
            if (quest == null)
            {
                quest = turnedInQuests.Find(q => q.questName == questName);
            }
        }
        return quest;
    }

    // Loads quest information
    // Parameters checks for any saved Quests and if there is an active one, their quest steps
    public void LoadQuestData(List<QuestData> savedQuests, List<QuestStepData> questStepData)
    {
        Debug.Log("Loading quest data...");

        activeQuests.Clear();
        completedQuests.Clear();
        turnedInQuests.Clear();

        foreach (var questData in savedQuests)
        {
            Quest quest = ScriptableObject.CreateInstance<Quest>(); // Create a new quest instance
            quest.questName = questData.questName;
            quest.questDescription = questData.questDescription;
            quest.rewardGold = questData.rewardGold;
            quest.steps = new List<QuestStep>(); // Initialize quest steps list

            if (questData.isActive)
                quest.questState = QuestState.Accepted;
            else if (questData.isCompleted)
                quest.questState = QuestState.Completed;
            else if (questData.isTurnedIn)
                quest.questState = QuestState.TurnedIn;

            // Add the quest to the appropriate list based on its state
            if (quest.questState == QuestState.Accepted)
                activeQuests.Add(quest);
            else if (quest.questState == QuestState.Completed)
                completedQuests.Add(quest);
            else if (quest.questState == QuestState.TurnedIn)
                turnedInQuests.Add(quest);

            foreach (var stepData in questStepData)
            {
                if (quest.questName == stepData.questName) // Match step to the correct quest
                {
                    Debug.Log("Test");
                    QuestStep step = new QuestStep
                    {
                        stepDescription = stepData.stepDescription,
                        stepType = stepData.questType,
                        targetCount = stepData.targetCount,
                        currentCount = stepData.currentCount,
                    };
                    quest.steps.Add(step);
                }
            }

            questLog.UpdateQuestLogUI(); // Update the UI
        }
    }
}
