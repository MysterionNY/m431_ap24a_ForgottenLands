using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For basic Text component
using TMPro;          // For TextMeshPro component

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public TextMeshProUGUI HPText;
    private Coroutine flashCoroutine;

    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Reference to Animator component
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
        else
        {
            // Start the flashing coroutine, but stop any previous one first
            if (flashCoroutine != null)
            {
                StopCoroutine(flashCoroutine);
            }
            flashCoroutine = StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        Color originalColor = spriteRenderer.color;
        Color flashColor = new Color(1f, 0f, 0f, 0.5f); // Solid red color
        float flashDuration = 0.1f; // Time between flashes
        int flashCount = 3; // Number of flashes

        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = flashColor; // Set the color to red
            yield return new WaitForSeconds(flashDuration);

            spriteRenderer.color = originalColor; // Reset the color back to the original
            yield return new WaitForSeconds(flashDuration);
        }

        // Ensure the color is reset to original after flashing
        spriteRenderer.color = originalColor;

        flashCoroutine = null; // Reset the coroutine reference
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
        // For example, disabling the player's movement script or collider:
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Optionally, you can wait until the animation is done before doing further actions
        StartCoroutine(HandleDeathAfterAnimation());
    }

    private IEnumerator HandleDeathAfterAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
    }
}
