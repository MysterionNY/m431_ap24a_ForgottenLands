using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer shadowRenderer;
    private Animator animator;
    public TextMeshProUGUI HPText;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;

    public PotionManager potionManager;
    public QuestManager questManager;
    public CurrencyManager currencyManager;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        shadowRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        questManager = FindObjectOfType<QuestManager>();
        potionManager = FindObjectOfType<PotionManager>();
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            StartCoroutine(FlashRed());
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

    public void Die()
    {
        if (isDead) return; // Prevent Die from being called multiple times
        isDead = true;
        if(potionManager.isHealthPotionActive){
            potionManager.healthPotionsAvailable += 1;
            potionManager.UpdatePotionDisplay();
        } else{
            potionManager.staminaPotionsAvailable += 1;
            potionManager.UpdatePotionDisplay();
        }
        currencyManager.gold += 25;
        currencyManager.UpdateCurrencyUI();
        questManager.EnemyKilled("Enemy");

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
