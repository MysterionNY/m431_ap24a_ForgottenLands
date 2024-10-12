using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float specialAttackCooldown = 15f;
    public float attackRange = 1.5f;
    public float detectionRadius = 5f; // Add this field for detection radius
    public Collider2D fireAOECollider;
    public int fireDamage = 20;
    public int normalAttackDamage = 10;

    // Idle behavior variables
    public Transform idleCenter; // Center of the idle area
    public float idleRadius = 3f; // Idle wander radius around the center
    public float idleWaitTime = 2f; // Time spent at each idle point
    private Vector2 idleTarget; // Current idle target position
    private bool isIdle = true; // Track whether the boss is idling

    private float specialAttackTimer;
    private bool isUsingSpecialAttack = false;
    private bool isAttacking = false;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public AudioSource fireSound;

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

        // Set the first random idle target
        SetNewIdleTarget();
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        specialAttackTimer -= Time.deltaTime;

        // Check if the player is within detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            // If the player is within the attack range, decide whether to attack
            if (distanceToPlayer <= attackRange)
            {
                if (CanUseSpecialAttack())
                {
                    UseSpecialAttack();
                }
                else if (!isAttacking)
                {
                    StartCoroutine(PerformSlashAttack());
                }
            }
            else
            {
                // Move towards the player if out of attack range
                ChasePlayer();
            }
        }
        else
        {
            // If the player is out of the detection radius, handle idle behavior
            IdleBehavior();
        }
    }

    private bool CanUseSpecialAttack()
    {
        return specialAttackTimer <= 0 && !isUsingSpecialAttack;
    }

    private void UseSpecialAttack()
    {
        if (isUsingSpecialAttack) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            isUsingSpecialAttack = true;
            specialAttackTimer = specialAttackCooldown; // Reset the cooldown
            animator.SetBool("IsUsingSpecialAttack", true);
            if (fireSound != null)
            {
                StartCoroutine(AdjustFireSoundVolume(true));
                fireSound.Play();
            }
        }
    }

    private IEnumerator PerformSlashAttack()
    {
        isAttacking = true;
        StopMovement(); // Ensure the boss stops moving during the attack

        // Trigger normal attack animation
        animator.SetTrigger("SlashAttack");

        // Wait for the attack animation to complete (customize timing based on animation length)
        yield return new WaitForSeconds(1f);

        // Reset attack state
        isAttacking = false;
    }

    public void DealSlashDamage()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(normalAttackDamage);
            }
        }
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
        animator.SetBool("IsUsingSpecialAttack", false);

        if (fireSound != null)
        {
            StartCoroutine(AdjustFireSoundVolume(false));
        }
    }

    private void ChasePlayer()
    {
        if (isAttacking) return;

        StopIdleBehavior(); // Stop idle behavior when chasing

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

    private void IdleBehavior()
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
        else
        {
            // If not idling, we can start idling again
            SetNewIdleTarget();
        }
    }

    private void MoveTowards(Vector2 target)
    {
        if (isAttacking) return; // Do not move if attacking

        rb.velocity = (target - (Vector2)transform.position).normalized * moveSpeed;

        // Update walking animation
        animator.SetBool("IsWalking", rb.velocity.magnitude > 0);

        // Flip the sprite based on movement direction
        spriteRenderer.flipX = rb.velocity.x < 0;
    }

    private void SetNewIdleTarget()
    {
        // Pick a random point within the idle radius around the idle center
        Vector2 randomPoint = Random.insideUnitCircle * idleRadius;
        idleTarget = (Vector2)idleCenter.position + randomPoint;
    }

    private IEnumerator WaitBeforeNewIdleTarget()
    {
        isIdle = false;
        yield return new WaitForSeconds(idleWaitTime);
        SetNewIdleTarget(); // Choose a new idle point
        isIdle = true;
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

    private IEnumerator AdjustFireSoundVolume(bool increase)
    {
        float duration = 0.2f;
        float elapsedTime = 0f;
        float startVolume = increase ? 0f : fireSound.volume;
        float endVolume = increase ? 0.3f : 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            fireSound.volume = Mathf.Lerp(startVolume, endVolume, elapsedTime / duration);
            yield return null;
        }

        if (!increase)
        {
            fireSound.Stop(); // Stop the sound when fading out is complete
        }
    }

    private void StopIdleBehavior()
    {
        isIdle = false; // Stop idling when chasing the player
    }
}
