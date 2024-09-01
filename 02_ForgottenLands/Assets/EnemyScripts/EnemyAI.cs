using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Assign the player in the Inspector
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;

    private float attackCooldownTimer;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
    private bool isMoving;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attackCooldownTimer = 0f;
        isAttacking = false;
        isMoving = false;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Within attack range
            if (attackCooldownTimer <= 0f && !isAttacking)
            {
                StartCoroutine(PerformAttack());
            }
            else
            {
                StopMovement();
            }
        }
        else
        {
            // Move towards the player if out of range
            MoveTowardsPlayer();
        }

        // Update cooldown timer
        attackCooldownTimer -= Time.deltaTime;
    }

    void MoveTowardsPlayer()
    {
        if (isAttacking) return; // Do not move if attacking

        isMoving = true;
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Flip the sprite based on movement direction
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;  // Face right
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;  // Face left
        }

        // Update walking animation
        animator.SetBool("IsWalking", rb.velocity.magnitude > 0);
    }

    void StopMovement()
    {
        isMoving = false;
        rb.velocity = Vector2.zero;
        animator.SetBool("IsWalking", false);
    }

    IEnumerator PerformAttack()
    {
        isAttacking = true;
        StopMovement(); // Ensure movement is stopped during attack

        // Trigger attack animation
        animator.SetTrigger("SlashAttack01");

        // Wait for the attack animation to complete
        yield return new WaitForSeconds(attackCooldown);

        // Reset attack state
        isAttacking = false;
        attackCooldownTimer = attackCooldown; // Reset cooldown timer
    }

    // Called by Animation Event
    void DealDamage()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }
    }
}
