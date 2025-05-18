using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    float moveSpeed = 5f;
    public float jumpForce = 7f;

    Rigidbody2D rb;
    Animator animator;
    Vector2 moveInput;
    bool isFacingRight = true;
    bool isGrounded = false;
    public int maxHealth = 5;
    public int currentHealth;

    public int currentStacks = 0;
    public StacksBar_Script stacksBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        stacksBar.SetMaxStacks(11);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.linearVelocityX));
        animator.SetFloat("yVelocity", rb.linearVelocityY);
        FlipSprite();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);

        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FlipSprite()
    {
        if ((moveInput.x > 0 && !isFacingRight) || (moveInput.x < 0 && isFacingRight))
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = !isFacingRight;
            /*Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;*/
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true ;
        animator.SetBool("isJumping", !isGrounded);
    }

    // Health control methods
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took damage. Current health: " + currentHealth);
        // TODO: Add visual feedback, check for death, etc.
        animator.SetTrigger("isHit");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed. Current health: " + currentHealth);
    }

    public void CollectStack(int amount)
    {
        currentStacks += amount;
        Debug.Log("Collected Stack. Current stacks: " + currentStacks);

        stacksBar.SetStacks(currentStacks);

    }
}
