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

    // Add other static game settings here
}
