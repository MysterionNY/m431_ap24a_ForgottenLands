using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueAttack : MonoBehaviour
{
    public Animator animator;
    public float attackCooldown = 0.2f;
    private float lastAttackTime = 0f;
    public float attackDamage = 10;
    private bool isAttacking = false;

    public float attackStaminaCost = 0.1f;
    private PlayerStamina ps;

    // Leveling and Upgrade System
    public int currentAttackLevel = 1;     // Starting attack level
    public int maxAttackLevel = 10;        // Max attack level
    public float upgradeCost = 50f;        // Base cost of first upgrade
    public float costMultiplier = 1.75f;   // Multiplier to increase cost per upgrade
    public float damageIncrease = 1.5f;    // Damage increase per upgrade

    private CurrencyManager currencyManager; // Reference to the currency manager

    // Once the game instance has started, these are the starting arguments
    void Start()
    {
        ps = GetComponent<PlayerStamina>();
        if (ps == null)
        {
            Debug.LogError("PlayerStamina script not found!");
        }

        currencyManager = FindObjectOfType<CurrencyManager>(); // Find the CurrencyManager in the scene
        if (currencyManager == null)
        {
            Debug.LogError("CurrencyManager not found!");
        }
    }

    // Updates every frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= lastAttackTime + attackCooldown && !isAttacking && ps.currentStamina >= attackStaminaCost)
        {
            StartCoroutine(PerformAttack());
        }
    }

    // Stops movement to perform attack with the given animation
    // IEnumerator gives us the possibility to use a couroutine
    // Couroutine gives us the possibility to execute code over time
    IEnumerator PerformAttack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        ps.currentStamina -= attackStaminaCost;
        ps.currentStamina = Mathf.Clamp01(ps.currentStamina);

        ps.lastActionTime = Time.time;

        animator.SetTrigger("SlashAttack01");

        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
        animator.SetTrigger("Idle");
    }

    // Deals damage if the enemy is tagged with "enemy" or with "boss"
    void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 0.5f); 
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
            }
        }

        Collider2D[] hitBosses = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D bosses in hitBosses)
        {
            if (bosses.CompareTag("Boss"))
            {
                BossHealth bossHealth = bosses.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(attackDamage);
                }
            }

        }
    }

    // Method to handle upgrading attack damage
    // returns a bool that is true when you have enough gold and damage level isnt higher than 10
    public bool UpgradeAttack()
    {
        if (currentAttackLevel < maxAttackLevel && currencyManager.gold >= upgradeCost)
        {
            // Deduct the cost from the player's gold
            currencyManager.SubtractGold((int)upgradeCost);
            
            // Increase attack damage and level
            attackDamage += damageIncrease;
            currentAttackLevel++;

            // Update the cost for the next upgrade
            upgradeCost *= costMultiplier;

            return true; // Upgrade successful
        }
        else
        {
            Debug.Log("Not enough gold or already at max level!");
            return false; // Upgrade failed
        }
    }

    // Loads attack information
    // Data loads the saved information
    public void LoadAttackData(GameData data)
    {
        attackDamage = data.attackDamage;
        currentAttackLevel = data.curAttackLvl;
        upgradeCost = data.upgradeCost;
    }
}
