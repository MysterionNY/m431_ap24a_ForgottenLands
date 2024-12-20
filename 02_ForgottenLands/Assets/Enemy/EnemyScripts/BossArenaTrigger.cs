using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    public GameObject bossHPUI;  // Reference to the boss HP UI
    public GameObject boss;      // Reference to the boss object

    // Checks if the Player is in the given arena
    // Parameter checks that the collider is infact an object with the Tag "Player"
    // Void, its based off a trigger event
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the boss HP UI when the player enters the arena
            bossHPUI.SetActive(true);
            boss.GetComponent<BossHealth>().isPlayerInArena = true; // Mark that player is in the arena
        }
    }

    // Checks if the Player has left the arena
    // Parameter checks that the collider is infact an object with the Tag "Player"
    // Void, its based off a trigger event
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the boss HP UI when the player exits the arena
            bossHPUI.SetActive(false);
            boss.GetComponent<BossHealth>().isPlayerInArena = false; // Mark that player is out of the arena
        }
    }
}
