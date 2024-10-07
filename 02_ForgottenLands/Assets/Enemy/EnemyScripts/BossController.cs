using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float specialAttackCooldown = 15f;
    public float attackRange = 1.5f;
    public Collider2D fireAOECollider;
    public int fireDamage = 20;
    public int normalAttackDamage = 10;

    private float specialAttackTimer;
    private bool isUsingSpecialAttack = false;
    private bool isAttacking = false;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Initialization
        specialAttackTimer = specialAttackCooldown;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }

        // Disable fire collider initially
        if (fireAOECollider != null)
        {
            fireAOECollider.enabled = false;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        specialAttackTimer -= Time.deltaTime;

        // Decide between special and normal attack or chase behavior
        if (distanceToPlayer <= attackRange)
        {
            if (CanUseSpecialAttack())
            {
                UseSpecialAttack();
            }
            else if (!isAttacking)
            {
                StartCoroutine(PerformNormalAttack());
            }
        }
        else
        {
            ChasePlayer();
        }
    }

    private bool CanUseSpecialAttack()
    {
        return specialAttackTimer <= 0 && !isUsingSpecialAttack;
    }

    private void UseSpecialAttack()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            isUsingSpecialAttack = true;
            specialAttackTimer = specialAttackCooldown; // Reset the cooldown
            GetComponent<Animator>().SetTrigger("SpecialAttack");
        }
    }

    private IEnumerator PerformNormalAttack()
    {
        isAttacking = true;
        StopMovement(); // Ensure the boss stops moving during the attack

        // Trigger normal attack animation
        animator.SetTrigger("NormalAttack");

        // Wait for the attack animation to complete (customize timing based on animation length)
        yield return new WaitForSeconds(1f);

        // Reset attack state
        isAttacking = false;
    }

    // Called by Animation Event to enable the fire AOE during the special attack
    public void EnableFireAOE()
    {
        if (fireAOECollider != null)
        {
            fireAOECollider.enabled = true;
        }
    }

    // Called by Animation Event to disable the fire AOE after the special attack ends
    public void DisableFireAOE()
    {
        if (fireAOECollider != null)
        {
            fireAOECollider.enabled = false;
        }
        isUsingSpecialAttack = false;
    }

    private void ChasePlayer()
    {
        if (isAttacking) return;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;

        // Update walking animation
        animator.SetBool("IsWalking", rb.velocity.magnitude > 0);

        // Flip sprite based on direction
        spriteRenderer.flipX = rb.velocity.x < 0;
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
        animator.SetBool("IsWalking", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (fireAOECollider != null && fireAOECollider.enabled && other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(fireDamage);
            }
        }
    }
}
