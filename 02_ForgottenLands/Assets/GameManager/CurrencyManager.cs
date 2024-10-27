using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int gold;                  // The amount of gold the player has
    public TextMeshProUGUI goldText; // Reference to the TextMeshPro component to display gold

    // Once the game instance has started, these are the starting arguments
    private void Start()
    {
        UpdateCurrencyUI();
    }

    // A function that can be called to give gold
    // Parameter will return the amount of gold that can be given out when calling the function
    public void AddGold(int amount)
    {
        gold += amount;
        UpdateCurrencyUI();
    }

    // A function that can be called to subtract gold
    // Parameter will return the amount of gold that can be subtracted when calling the function
    public void SubtractGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateCurrencyUI();
        }
        else
        {
            Debug.LogWarning("Not enough gold to subtract!");
        }
    }

    // Update the currency UI when new gold was received
    public void UpdateCurrencyUI()
    {
        if (goldText != null)
        {
            goldText.text = "" + gold.ToString();
        }
    }

    // Load the currency saved currency when using load game
    // Parameter defines the saved information it should take from
    public void LoadCurrencyManager(GameData data)
    {
        gold = data.gold;
        UpdateCurrencyUI();  // Update the UI after loading
    }
}