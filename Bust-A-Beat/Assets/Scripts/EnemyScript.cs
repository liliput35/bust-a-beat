using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 5f; // n units to patrol
    public int maxHealth = 5;
    private int currentHealth;

    private Vector3 startPoint;
    private Vector3 direction = Vector3.right;

    private void Start()
    {
        startPoint = transform.position;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        float distanceMoved = Vector3.Distance(startPoint, transform.position);
        if (distanceMoved >= patrolDistance)
        {
            direction *= -1;
            Flip();
            startPoint = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger && collision.gameObject.name == "Guni")
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        } 
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy took damage. Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
