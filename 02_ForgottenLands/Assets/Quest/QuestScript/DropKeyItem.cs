using UnityEngine;

public class DropKeyItem : MonoBehaviour
{
    public string itemName; // The name of the item, e.g., "KeyItem"
    private bool canPickUp = false;

    // Updates every frame
    void Update()
    {
        // Detect interaction when the player is near and presses 'E'
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    // When the tag is player, he will be able to pick up the item and if he is in range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true; // Player is in range to pick up the item
        }
    }

    // If the player is not in range or isn't a tag player, he won't be able to pick it up
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false; // Player leaves range
        }
    }

    // Remove the gameobject when picked up and update quest information
    private void PickUpItem()
    {
        // Notify QuestManager about the collected item
        QuestManager.instance.ItemCollected(itemName);

        // Destroy the item after pickup
        Destroy(gameObject);
    }
}
