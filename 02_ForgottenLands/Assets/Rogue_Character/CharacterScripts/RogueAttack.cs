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

    void Update()
    {
        // Check if attack button is pressed and enough time has passed since last attack
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= lastAttackTime + attackCooldown && !isAttacking)
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;

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
