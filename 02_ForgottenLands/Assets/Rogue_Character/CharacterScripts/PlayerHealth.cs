using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Image hpBarForeground;
    private Color originalColor;
    private Color flashColor = new Color(1f, 0f, 0f, 0.5f); // Solid red color

    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    private bool isFlashing = false;
    private float flashTimer = 0f;
    private float flashDuration = 0.1f; // Time for each flash
    private int flashCount = 3; // Number of flashes
    private int currentFlash = 0;
    private float originalWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color;
        UpdateHealthBar(); // Set initial HP bar value

        // Set original width
        originalWidth = hpBarForeground.rectTransform.sizeDelta.x;
    }

    void Update()
    {
        // Handle flashing
        HandleFlashingEffect();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Prevent damage if the player is dead

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Start the flashing effect
            isFlashing = true;
            flashTimer = 0f;
            currentFlash = 0;
        }

        UpdateHealthBar();
    }

    void Die()
    {
        if (isDead) return;  // Prevent multiple death triggers
        isDead = true;

        // Trigger the death animation
        if (animator != null)
        {
            animator.SetTrigger("DieTrigger");
        }

        // Disable player movement and interactions
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        StartCoroutine(HandleDeathAfterAnimation());
    }

    private IEnumerator HandleDeathAfterAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        // Hide the sprite renderer after death
        SceneManager.LoadScene("MainMenu");
    }

    void HandleFlashingEffect()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashDuration)
            {
                flashTimer = 0f;
                spriteRenderer.color = spriteRenderer.color == originalColor ? flashColor : originalColor;
                currentFlash++;

                // Stop flashing after reaching the flash count
                if (currentFlash >= flashCount * 2)
                {
                    spriteRenderer.color = originalColor;
                    isFlashing = false;
                    currentFlash = 0;
                }
            }
        }
    }

    void UpdateHealthBar()
    {
        if (hpBarForeground == null)
        {
            Debug.LogError("hpBarForeground is not assigned!");
            return;
        }

        float healthPercentage = Mathf.Clamp01((float)currentHealth / maxHealth);
        Debug.Log($"Health Percentage: {healthPercentage}");

        hpBarForeground.fillAmount = healthPercentage;
    }
}
