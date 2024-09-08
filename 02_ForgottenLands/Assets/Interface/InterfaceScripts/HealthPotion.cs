using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPotion : MonoBehaviour
{
    public float healPercentage = 0.65f; // 65% healing per potion
    public int potionsAvailable = 0; // Number of potions the player has
    public TMP_Text healthPotionAmount; // TextMeshPro UI component
    public Image potionImage; // Image component for the potion icon
    public Sprite fullPotionSprite; // Sprite for the full potion
    public Sprite emptyPotionSprite; // Sprite for the empty potion

    void Start()
    {
        UpdateHealthPotionCount();
        UpdatePotionImage();
    }

    public void UsePotion()
    {
        if (potionsAvailable > 0)
        {
            // Reduce the number of potions
            potionsAvailable--;

            // Heal the player
            HealPlayer();

            // Update the potion count display and image
            UpdateHealthPotionCount();
            UpdatePotionImage();

            Debug.Log("Health potion used. Healing player and reducing potions.");
        }
        else
        {
            Debug.Log("No health potions available to use.");
        }
    }

    void HealPlayer()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            int healAmount = Mathf.RoundToInt(playerHealth.maxHealth * healPercentage);
            playerHealth.Heal(healAmount);

            Debug.Log("Healed player by: " + healAmount + ". Current Health: " + playerHealth.currentHealth);
        }
        else
        {
            Debug.LogError("PlayerHealth not found!");
        }
    }

    public void UpdateHealthPotionCount()
    {
        if (healthPotionAmount != null)
        {
            healthPotionAmount.text = "" + potionsAvailable;
            Debug.Log("Updated potion count display to: " + potionsAvailable);
        }
        else
        {
            Debug.LogError("HealthPotionAmount TMP_Text is not assigned!");
        }
    }

    public void UpdatePotionImage()
    {
        if (potionImage != null)
        {
            potionImage.sprite = potionsAvailable > 0 ? fullPotionSprite : emptyPotionSprite;
        }
        else
        {
            Debug.LogError("PotionImage Image component is not assigned!");
        }
    }

    public void SetActive(bool isActive)
    {
        potionImage.gameObject.SetActive(isActive);
    }
}
