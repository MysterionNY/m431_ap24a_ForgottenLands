using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RogueMovement : MonoBehaviour
{
    public float moveSpeed = 2f;        // Speed of the character movement
    public float dashSpeed = 20f;       // How fast you dash
    public float dashDistance = 3.5f;     // Distance to dash (2 blocks wide)
    public float dashDuration = 0.2f;   // How long the dash lasts
    public float dashCooldown = 1f;     // Cooldown between dashes

    public bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 dashDirection;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerStamina ps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();           // Get the Rigidbody2D component
        animator = GetComponent<Animator>();        // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
        ps = GetComponent<PlayerStamina>();
    }

    void Update()
    {
        // Get movement input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Only allow movement input when not dashing
        if (!isDashing)
        {
            moveDirection = new Vector2(moveX, moveY).normalized;

            // Dash input (can be changed to any button, e.g., Left Shift)
            if (Input.GetKeyDown(KeyCode.L) && canDash && ps.currentStamina >= ps.dashStaminaCost)
            {
                StartCoroutine(Dash());
            }
        }

        // Update Animator parameters
        bool isMoving = moveDirection.sqrMagnitude > 0.001f; // Small threshold for movement
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetBool("IsWalking", isMoving);

        // Flip the sprite based on movement direction
        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;  // Face right
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;  // Face left
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            // Regular movement when not dashing
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;

        dashDirection = moveDirection == Vector2.zero ? new Vector2(spriteRenderer.flipX ? -1 : 1, 0) : moveDirection;

        Vector2 startPosition = rb.position;
        Vector2 dashDestination = startPosition + dashDirection * dashDistance;

        float startTime = Time.time;
        ps.currentStamina -= ps.dashStaminaCost; // Reduce stamina
        ps.currentStamina = Mathf.Clamp01(ps.currentStamina); // Ensure stamina stays between 0 and 1
        ps.lastActionTime = Time.time;       // Record the time of the last dash

        while (Time.time < startTime + dashDuration)
        {
            rb.MovePosition(Vector2.Lerp(startPosition, dashDestination, (Time.time - startTime) / dashDuration));
            yield return null;
        }

        rb.MovePosition(dashDestination);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
