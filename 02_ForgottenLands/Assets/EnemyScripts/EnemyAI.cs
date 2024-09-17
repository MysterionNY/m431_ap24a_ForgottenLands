using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    public float detectionRadius = 5f;  // Radius where enemy can detect player

    public Transform idleCenter;  // Center of the idle area
    public float idleRadius = 3f; // Idle wander radius around the center
    public float idleWaitTime = 2f; // Time spent at each idle point

    private float attackCooldownTimer;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
    private bool isMoving;
    private Vector2 idleTarget;
    private bool isIdle = true; // Track whether enemy is idling
    private bool isChasingPlayer = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attackCooldownTimer = 0f;
        isAttacking = false;
        isMoving = false;

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }

        // Set first random idle target within radius
        SetNewIdleTarget();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if player is within detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            isChasingPlayer = true;
            ChasePlayer();
        }
        else
        {
            isChasingPlayer = false;
            IdleBehavior();
        }

        // Update cooldown timer for attacks
        attackCooldownTimer -= Time.deltaTime;
    }

    void ChasePlayer()
    {
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
            MoveTowards(player.position);
        }
    }

    void IdleBehavior()
    {
        if (isIdle)
        {
            float distanceToIdleTarget = Vector2.Distance(transform.position, idleTarget);

            if (distanceToIdleTarget <= 0.2f)
            {
                // Reached the idle target, wait for a bit and set a new target
                StopMovement();
                StartCoroutine(WaitBeforeNewIdleTarget());
            }
            else
            {
                // Move towards the idle target
                MoveTowards(idleTarget);
            }
        }
    }

    void SetNewIdleTarget()
    {
        // Pick a random point within the idle radius around the idle center
        Vector2 randomPoint = Random.insideUnitCircle * idleRadius;
        idleTarget = (Vector2)idleCenter.position + randomPoint;
    }

    IEnumerator WaitBeforeNewIdleTarget()
    {
        isIdle = false;
        yield return new WaitForSeconds(idleWaitTime);
        SetNewIdleTarget(); // Choose a new idle point
        isIdle = true;
    }

    void MoveTowards(Vector2 target)
    {
        if (isAttacking) return; // Do not move if attacking

        isMoving = true;
        Vector2 direction = (target - (Vector2)transform.position).normalized;
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
