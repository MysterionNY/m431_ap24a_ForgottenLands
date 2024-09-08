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



    public GameData(PlayerHealth player, List<EnemyHealth> enemies, PotionManager potionManager)
    {
        // Player health and position
        Playerhealth = player.currentHealth;
        Playerposition = new float[3];
        Playerposition[0] = player.transform.position.x;
        Playerposition[1] = player.transform.position.y;
        Playerposition[2] = player.transform.position.z;

        // Enemy positions, states, and health
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
    }
}
