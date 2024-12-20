using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 500;
    public float currentHealth;
    public bool isPlayerInArena = false; // Tracks if the player is in the arena
    public bool isDead = false;
    private float originalWidth;
    private bool isFlashing = false;
    private float flashTimer = 0f;
    private float flashDuration = 0.1f;
    private int flashCount = 3;
    private int currentFlash = 0;

    private SpriteRenderer spriteRenderer;
    public QuestManager questManager;
    private Animator animator;
    public Image hpBarForeground;
    private Color originalColor;
    private Color flashColor = new Color(1f, 0f, 0f, 0.5f);

    public delegate void EnemyDeathHandler(GameObject enemy);
    public event EnemyDeathHandler OnDeath;

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        questManager = FindObjectOfType<QuestManager>();
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
    
    // When the Boss takes damage, he will flash through different colors to indicate damage
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

    // The Boss will receive damage when getting attacked
    // It updates the health bar or calls the Die function
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            isFlashing = true;
            flashTimer = 0f;
            currentFlash = 0;
        }
        UpdateHealthBar();
    }

    // When the boss dies, play the final cutscene scene
    void Die()
    {
        if (isDead) return;
        isDead = true;

        OnDeath?.Invoke(gameObject);
        Debug.Log("Boss defeated!");
        questManager.EnemyKilled("Enemy");
        SceneManager.LoadScene("CutSceneAfterKillingTheBoss");
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        HandleDeathAfterAnimation();
    }

    // Deactivate boss when he died
    private IEnumerator HandleDeathAfterAnimation()
    {
        // Wait for the animation to finish (assuming the animation length is 1.5 seconds)
        yield return new WaitForSeconds(1.5f);


        // Deactivate the enemy GameObject and its children
        gameObject.SetActive(false);
    }

    // When the boss receives damage, update the healthbar
    public void UpdateHealthBar()
    {
        if (hpBarForeground == null)
        {
            Debug.LogError("hpBarForeground is not assigned!");
            return;
        }

        float healthPercentage = Mathf.Clamp01((float)currentHealth / maxHealth);

        hpBarForeground.fillAmount = healthPercentage;
    }
}
