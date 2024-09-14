using UnityEngine;

public class DropKeyItem : MonoBehaviour
{
    public string itemName; // The name of the item, e.g., "KeyItem"
    private bool canPickUp = false;

    void Update()
    {
        // Detect interaction when the player is near and presses 'E'
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true; // Player is in range to pick up the item
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false; // Player leaves range
        }
    }

    private void PickUpItem()
    {
        // Notify QuestManager about the collected item
        QuestManager.instance.ItemCollected(itemName);

        // Destroy the item after pickup
        Destroy(gameObject);
    }
}
