using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float staminaRegenRate = 0.1667f; // 100% in 6 seconds (16.67% per second)
    public float dashStaminaCost = 0.15f;    // 15% stamina cost for each dash
    public float currentStamina = 1f;        // Stamina from 0 (empty) to 1 (full)
    public float lastActionTime = 0f;        // Time when the last dash occurred
    private float regenDelay = 1f;           // Delay before stamina starts regenerating (1 second)

    public Image StaminaBarForeground;
    private RogueMovement rm;

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        rm = GetComponent<RogueMovement>(); // Get the RogueMovement component
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStaminaBar();
    }

    // When this function is called, it will update the stamina bar
    public void UpdateStaminaBar()
    {
        if (StaminaBarForeground == null)
        {
            Debug.LogError("StaminaBarForeground is not assigned!");
            return;
        }

        // Check if at least 1 second has passed since the last action (dash or attack)
        if (!rm.isDashing && Time.time >= lastActionTime + regenDelay && currentStamina < 1f)
        {
            // Regenerate stamina after the 1 second delay
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp01(currentStamina); // Clamp between 0 and 1
        }

        StaminaBarForeground.fillAmount = currentStamina;
    }
}
