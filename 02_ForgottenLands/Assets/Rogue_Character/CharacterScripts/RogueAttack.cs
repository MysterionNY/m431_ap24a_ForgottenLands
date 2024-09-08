using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueAttack : MonoBehaviour
{
    public Animator animator; // Drag your Animator component here in the Inspector
    public float attackCooldown = 0.2f; // Cooldown time in seconds
    private float lastAttackTime = 0f;
    public int attackDamage = 10;
    private bool isAttacking = false;

    public float attackStaminaCost = 0.1f; // 20% stamina cost per attack

    private PlayerStamina ps;

    void Start()
    {
        // Find the RogueMovement component (assumed to be on the same GameObject)
        ps = GetComponent<PlayerStamina>();
        if (ps == null)
        {
            Debug.LogError("RogueMovement script not found on the same GameObject!");
        }
    }

    void Update()
    {
        // Check if the attack button is pressed, enough time has passed since last attack, and enough stamina is available
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= lastAttackTime + attackCooldown && !isAttacking && ps.currentStamina >= attackStaminaCost)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

        ps.currentStamina -= attackStaminaCost;
        ps.currentStamina = Mathf.Clamp01(ps.currentStamina); // Ensure it stays between 0 and 1

        // Set the last action time to delay stamina regeneration (affects dash too)
        ps.lastActionTime = Time.time;
        
        // Trigger attack animation
        animator.SetTrigger("SlashAttack01");

        // Wait for the attack animation to complete
        yield return new WaitForSeconds(0.5f); // Adjust this duration to match your animation length

        // Return to idle state
        isAttacking = false;
        animator.SetTrigger("Idle");
    }

    // Called by Animation Event
    void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Adjust radius as needed
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
    }
}
