using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public TextMeshProUGUI HPText;

    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    private bool isFlashing = false;
    private float flashTimer = 0f;
    private float flashDuration = 0.1f; // Time for each flash
    private int flashCount = 3; // Number of flashes
    private int currentFlash = 0;
    private Color originalColor;
    private Color flashColor = new Color(1f, 0f, 0f, 0.5f); // Solid red color

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // Update the text to show the current HP
        HPText.text = "HP: " + currentHealth.ToString();

        // Handle flashing
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashDuration)
            {
                flashTimer = 0f;
                spriteRenderer.color = spriteRenderer.color == originalColor ? flashColor : originalColor;
                currentFlash++;

                if (currentFlash >= flashCount * 2)
                {
                    // Reset everything after flashing is done
                    spriteRenderer.color = originalColor;
                    isFlashing = false;
                    currentFlash = 0;
                }
            }
        }
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
            // Start the flashing effect
            isFlashing = true;
            flashTimer = 0f;
            currentFlash = 0;
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (animator != null)
        {
            animator.SetTrigger("DieTrigger");
        }

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

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
