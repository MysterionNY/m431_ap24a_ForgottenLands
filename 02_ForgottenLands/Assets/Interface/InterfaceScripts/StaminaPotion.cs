using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaPotion : MonoBehaviour
{
    public int potionsAvailable = 0;
    public TMP_Text staminaPotionAmount; // TextMeshPro UI component
    public Image potionImage; // Image component for the potion icon
    public Sprite fullPotionSprite; // Sprite for the full potion
    public Sprite emptyPotionSprite; // Sprite for the empty potion
    private PlayerStamina ps;

    void Start()
    {
        // Find the PlayerStamina component or assign it through the Inspector
        ps = FindObjectOfType<PlayerStamina>();

        // Initialize potion UI
        UpdateStaminaPotionCount();
        UpdateStaminaPotionImage();
    }

    public void UseStaminaPotion()
    {
        if (potionsAvailable > 0)
        {
            // Reduce the number of potions
            potionsAvailable--;

            // Restore stamina
            ps.currentStamina = 1f;
            ps.UpdateStaminaBar();

            // Update the potion count display and image
            UpdateStaminaPotionCount();
            UpdateStaminaPotionImage();

            Debug.Log("Stamina potion used. Stamina is now full.");
        }
        else
        {
            Debug.Log("No stamina potions available to use.");
        }
    }

    public void UpdateStaminaPotionCount()
    {
        if (staminaPotionAmount != null)
        {
            staminaPotionAmount.text = "" + potionsAvailable;
            Debug.Log("Updated stamina potion count display to: " + potionsAvailable);
        }
        else
        {
            Debug.LogError("StaminaPotionAmount TMP_Text is not assigned!");
        }
    }

    public void UpdateStaminaPotionImage()
    {
        if (potionImage != null)
        {
            // Update potion image based on potion count
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
