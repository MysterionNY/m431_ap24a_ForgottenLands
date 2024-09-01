using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
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
        // Optionally play a death animation or sound

        // Hide the enemy by disabling the SpriteRenderer
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        // If needed, you can also disable the collider
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }
}
