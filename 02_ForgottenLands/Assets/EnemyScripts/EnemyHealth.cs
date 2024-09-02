using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer shadowRenderer;
    private Animator animator;
    public TextMeshProUGUI HPText;
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shadowRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Update the text to show the current HP
        HPText.text = "HP: " + currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        Color originalColor = spriteRenderer.color;
        Color flashColor = new Color(1f, 0f, 0f, 0.5f);
        float flashDuration = 0.1f; // Time between flashes
        int flashCount = 3; // Number of flashes

        for (int i = 0; i < flashCount; i++)
        {
            // Set the color to red
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashDuration);

            // Reset the color back to the original
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }

    void Die()
    {
        if (isDead) return; // Prevent Die from being called multiple times
        isDead = true;

        // Trigger the death animation
        if (animator != null)
        {
            animator.SetTrigger("DieTrigger");
        }

        // Optionally disable movement or other components immediately
        // For example, disabling the enemy's movement script or collider:
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Turn off the GameObject after the animation finishes
        StartCoroutine(HandleDeathAfterAnimation());
    }

    private IEnumerator HandleDeathAfterAnimation()
    {
        // Wait for the animation to finish (assuming the animation length is 1.5 seconds)
        yield return new WaitForSeconds(1.5f);

        // Deactivate the enemy GameObject and its children
        gameObject.SetActive(false);
    }
}
