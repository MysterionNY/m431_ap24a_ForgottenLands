using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    public GameObject bossHPUI;  // Reference to the boss HP UI
    public GameObject boss;      // Reference to the boss object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the boss HP UI when the player enters the arena
            bossHPUI.SetActive(true);
            boss.GetComponent<BossHealth>().isPlayerInArena = true; // Mark that player is in the arena
        }
    }

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
