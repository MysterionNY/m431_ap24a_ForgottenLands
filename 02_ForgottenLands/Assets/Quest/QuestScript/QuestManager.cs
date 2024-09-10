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
    private void Awake()
    {
            DontDestroyOnLoad(gameObject);
    }
    public void EnemyKilled(string enemyType)
    {
        // Temporary list to store quests that need to be processed
        List<Quest> questsToComplete = new List<Quest>();

        // Iterate through the active quests
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

        // Process completed quests after the iteration
        foreach (var quest in questsToComplete)
        {
            CompleteQuest(quest);
            Debug.Log("Quest Completed: " + quest.questName);
        }
    }

    public void AcceptQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest) && !completedQuests.Contains(quest) && !turnedInQuests.Contains(quest))
        {
            quest.questState = QuestState.Accepted;
            activeQuests.Add(quest);
            questLog.UpdateQuestLogUI();
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (quest.CheckCompletion())
        {
            quest.questState = QuestState.Completed;
            activeQuests.Remove(quest);
            completedQuests.Add(quest);

            questLog.UpdateQuestLogUI();
        }
    }

    public void TurnInQuest(Quest quest)
    {
        if (quest.questState == QuestState.Completed)
        {
            quest.questState = QuestState.TurnedIn;
            RewardPlayer(quest.rewardGold);
            completedQuests.Remove(quest);
            turnedInQuests.Add(quest);
            questLog.UpdateQuestLogUI();
        }
    }

    void RewardPlayer(int goldAmount)
    {
        currencyManager.AddGold(goldAmount);
    }

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
