using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 5f;
    public float detectionRange = 3f; 
    public int maxHealth = 5;

    private int currentHealth;
    private Vector3 startPoint;
    private bool isFacingRight = true;
    private Transform playerTransform;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 1f; // seconds between shots
    private float nextFireTime = 0f;


    private void Start()
    {
        startPoint = transform.position;
        currentHealth = maxHealth;

        GameObject player = GameObject.Find("Guni"); 
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found! Make sure the player GameObject is named 'Guni'.");
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer <= detectionRange)
            {
                if (Time.time >= nextFireTime)
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
                return;
            }
        }


        // Patrol logic
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        float distanceMoved = Vector3.Distance(startPoint, transform.position);
        if (distanceMoved >= patrolDistance)
        {
            Flip();
            startPoint = transform.position;
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
        gameObject.SetActive(false);
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
    }

    private void Shoot() 
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
