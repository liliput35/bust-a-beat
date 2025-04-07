using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    float moveSpeed = -5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Apply the initial leftward velocity in Start
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void FixedUpdate()
    {
        // In FixedUpdate, simply maintain the horizontal velocity
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }
}