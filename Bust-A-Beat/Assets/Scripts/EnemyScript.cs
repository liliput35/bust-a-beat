using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private int direction = -1; // -1 = left, 1 = right

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        // Continuously apply horizontal velocity
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger)
        {
            // If the enemy hits the player (named Guni), apply damage
            if (collision.gameObject.name == "Guni")
            {
                PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
                if (player != null)
                {
                    player.TakeDamage(1); // Deduct 1 health
                }
            }
            else
            {
                // Reverse direction if it hits anything else
                direction *= -1;
                Flip();
            }
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
