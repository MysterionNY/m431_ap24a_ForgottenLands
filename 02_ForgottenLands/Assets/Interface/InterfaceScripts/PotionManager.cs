using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public int healthPotionsAvailable = 0;  // Number of health potions the player has
    public int staminaPotionsAvailable = 0; // Number of stamina potions the player has
    public TMP_Text potionText;         // Text for displaying potion count
    public Image potionImage;           // Image for the active potion
    public Sprite healthPotionSprite;   // Sprite for health potion
    public Sprite staminaPotionSprite;  // Sprite for stamina potion
    public Sprite emptyPotionSprite;    // Sprite for empty potion (for both types)

    public bool isHealthPotionActive = true; // Tracks whether health potion is active
    private PlayerHealth playerHealth;        // Reference to PlayerHealth
    private PlayerStamina playerStamina;      // Reference to PlayerStamina

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerStamina = FindObjectOfType<PlayerStamina>();

        // Initial potion UI update
        UpdatePotionDisplay();
    }

    void Update()
    {
        // Switch active potion when Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHealthPotionActive = !isHealthPotionActive;
            UpdatePotionDisplay();
        }

        // Use the active potion when F is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseActivePotion();
        }
    }

    void UseActivePotion()
    {
        if (isHealthPotionActive)
        {
            // Use health potion
            if (healthPotionsAvailable > 0)
            {
                healthPotionsAvailable--;
                playerHealth.Heal(65); // Heal the player by 65%
            }
        }
        else
        {
            // Use stamina potion
            if (staminaPotionsAvailable > 0)
            {
                staminaPotionsAvailable--;
                playerStamina.currentStamina = 1f; // Restore full stamina
            }
        }

        // Update potion display after using the potion
        UpdatePotionDisplay();
    }

    public void UpdatePotionDisplay()
    {
        // Update the UI based on the active potion
        if (isHealthPotionActive)
        {
            potionImage.sprite = healthPotionsAvailable > 0 ? healthPotionSprite : emptyPotionSprite;
            potionText.text = "" + healthPotionsAvailable;
        }
        else
        {
            potionImage.sprite = staminaPotionsAvailable > 0 ? staminaPotionSprite : emptyPotionSprite;
            potionText.text = "" + staminaPotionsAvailable;
        }
    }

    /* Save both potion counts
    public GameData SavePotionData(GameData data)
    {
        data.healthPotions = healthPotionsAvailable;
        data.staminaPotions = staminaPotionsAvailable;
        return data;
    }*/

    // Load both potion counts
    public void LoadPotionData(GameData data)
    {
        healthPotionsAvailable = data.healthPotions;
        staminaPotionsAvailable = data.staminaPotions;
        UpdatePotionDisplay();  // Update the UI after loading
    }
}
