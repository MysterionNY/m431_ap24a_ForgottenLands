using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game/GameSettings")]
public class GameSettings : ScriptableObject
{
    public Vector3 playerStartPosition;
    public Vector3[] enemyStartPositions;
    public int initialPlayerHealth;
    public int[] enemyInitialHealths; // If each enemy starts with different health values
    public int healthPotions;
    public int staminaPotions;
    public List<QuestSettings> quests; // Add this line

    [System.Serializable]
    public class QuestSettings
    {
        public string questName;
        public bool isActive;
        public bool isCompleted;
        public int progress; // Example: progress in quest steps
    }
}
