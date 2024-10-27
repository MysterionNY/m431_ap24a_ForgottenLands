using System;
using System.Collections.Generic;
using UnityEngine;


// Create a scriptableobject to create quests
[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    public string questDescription;
    public List<QuestStep> steps = new List<QuestStep>();
    public int rewardGold;
    public QuestState questState;

    public bool CheckCompletion()
    {
        foreach (var step in steps)
        {
            if (!step.isCompleted)
            {
                return false;
            }
        }
        questState = QuestState.Completed;
        return true;
    }
}

// A list of quest status
public enum QuestState
{
    NotStarted,
    Accepted,
    InProgress,
    Completed,
    TurnedIn
}

// A list of quest types
public enum QuestStepType { KillEnemies, CollectItems, TalkToNPC, KillBoss }

// Showcases queststeps
[Serializable]
public class QuestStep
{
    public string questName;
    public string stepDescription;
    public QuestStepType stepType;       // Define the type of quest step
    public int targetCount;              // The target count for kills or items to collect
    [NonSerialized]
    public int currentCount;             // Tracks how many have been completed
    public bool isCompleted
    {
        get { return currentCount >= targetCount; }  // Completed when the target is reached
    }

    public void IncrementCount()
    {
        if (!isCompleted)
        {
            currentCount++;
        }
    }
}