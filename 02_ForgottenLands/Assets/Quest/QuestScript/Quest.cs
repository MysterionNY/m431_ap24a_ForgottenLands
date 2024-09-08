using System;
using System.Collections.Generic;
using UnityEngine;

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



public enum QuestState
{
    NotStarted,
    Accepted,
    InProgress,
    Completed,
    TurnedIn
}

public enum QuestStepType { KillEnemies, CollectItems, TalkToNPC }

[System.Serializable]
public class QuestStep
{
    public string stepDescription;
    public QuestStepType stepType;       // Define the type of quest step
    public int targetCount;              // The target count for kills or items to collect
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