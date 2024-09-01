using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed of the character movement

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        animator = GetComponent<Animator>();  // Get the Animator component
        spriteRenderer = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (movement.sqrMagnitude > 0)
        {
            movement.Normalize();
        }

        bool isMoving = movement.sqrMagnitude > 0.001f; // Small threshold

        // Update Animator parameters
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetBool("IsWalking", isMoving);

        // Flip the sprite based on movement direction
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;  // Face right
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;  // Face left
        }
    }

    void FixedUpdate()
    {
        // Move the character
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
