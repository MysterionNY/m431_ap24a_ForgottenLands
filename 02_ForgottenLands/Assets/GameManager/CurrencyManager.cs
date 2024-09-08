using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int gold;                  // The amount of gold the player has
    public TextMeshProUGUI goldText; // Reference to the TextMeshPro component to display gold

    private void Start()
    {
        UpdateCurrencyUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateCurrencyUI();
    }

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

    private void UpdateCurrencyUI()
    {
        if (goldText != null)
        {
            goldText.text = "" + gold.ToString();
        }
    }

    public void LoadCurrencyManager(GameData data)
    {
        gold = data.gold;
        UpdateCurrencyUI();  // Update the UI after loading
    }
}