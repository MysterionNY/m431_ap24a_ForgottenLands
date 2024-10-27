using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;                // Enemy prefab to spawn
    public Transform[] spawnAreas;                // List of spawn areas (idle centers)
    public float spawnRadius = 3f;                // Radius within each spawn area
    public int[] maxEnemiesPerArea;               // Array to define max enemies for each spawn area
    public float spawnInterval = 5f;              // Time between spawns
    public Transform enemyParent;                 // Parent object to contain enemies

    private Dictionary<Transform, int> enemiesPerArea;  // Track enemies per area

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        enemiesPerArea = new Dictionary<Transform, int>();
        for (int i = 0; i < spawnAreas.Length; i++)
        {
            enemiesPerArea.Add(spawnAreas[i], 0);  // Initialize enemy count per area
        }

        StartCoroutine(SpawnEnemies());
    }

    // Spawn enemies in certain spawn areas
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Randomly select a spawn area
            Transform selectedArea = GetRandomSpawnArea();

            // Get the index of the selected spawn area to check the enemy limit
            int areaIndex = System.Array.IndexOf(spawnAreas, selectedArea);

            // Check if we can spawn more enemies in that area
            if (enemiesPerArea[selectedArea] < maxEnemiesPerArea[areaIndex])
            {
                SpawnEnemy(selectedArea, areaIndex);
            }
        }
    }

    // Define the random spawn radius
    Transform GetRandomSpawnArea()
    {
        return spawnAreas[Random.Range(0, spawnAreas.Length)];
    }

    // Spawn enemies in a random radius of the spawn point
    void SpawnEnemy(Transform spawnArea, int areaIndex)
    {
        // Pick a random position within the spawn area radius
        Vector2 spawnPosition = (Vector2)spawnArea.position + Random.insideUnitCircle * spawnRadius;

        // Instantiate the enemy and set the parent
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, enemyParent);

        // Set the idle center for this enemy
        EnemyAI enemyAI = newEnemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            enemyAI.idleCenter = spawnArea;
        }

        // Update the number of enemies in this area
        enemiesPerArea[spawnArea]++;

        // Attach to the enemy health event to track deaths
        EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.OnDeath += (enemy) => HandleEnemyDeath(spawnArea, newEnemy);
        }
    }

    void HandleEnemyDeath(Transform spawnArea, GameObject enemy)
    {
        // Decrease the enemy count for this area when an enemy dies
        enemiesPerArea[spawnArea]--;
    }
}
