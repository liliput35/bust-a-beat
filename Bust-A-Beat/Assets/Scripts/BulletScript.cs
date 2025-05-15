using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float maxDistance = 10f;
    private Vector2 startPosition;


    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        startPosition = transform.position;

    }

     void Update()
    {
        float distanceTraveled = Vector2.Distance(startPosition, transform.position);
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.name == "Enemy" || collision.gameObject.name.Contains("WhiteBear") || collision.gameObject.name.Contains("BrownBear"))
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
        } else if (collision.gameObject.name == "Guni") 
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.TakeDamage(1);
            }
        }
        
    }

}
