using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For basic Text component
using TMPro;          // For TextMeshPro component

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int maxHealth = 20;
    private int currentHealth;
    public TextMeshProUGUI HPText;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Update the text to show the current HP
        HPText.text = "HP: " + currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}
