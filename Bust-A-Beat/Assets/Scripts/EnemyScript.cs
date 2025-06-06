using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 5f;
    public float detectionRange = 3f; 
    public int maxHealth = 5;

    public int currentHealth;
    private Vector3 startPoint;
    private Vector3 lastPosition;

    private bool isFacingRight = true;
    private Transform playerTransform;

    public Transform firePoint;
    public Transform deathPoint;
    public GameObject deathFXPrefab;
    public GameObject coinPrefab;


    public GameObject bulletPrefab;
    public float fireRate = 1f; // seconds between shots
    private float nextFireTime = 0f;

    Animator animator;



    private void Start()
    {
        startPoint = transform.position;
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        lastPosition = transform.position;



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

                animator.SetFloat("xVelocity", 0f);
                return;
            }
        }


        // Patrol logic
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Calculate actual movement speed
        float xVelocity = (transform.position.x - lastPosition.x) / Time.deltaTime;
        animator.SetFloat("xVelocity", Math.Abs(xVelocity));

        lastPosition = transform.position;

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
            Instantiate(deathFXPrefab, deathPoint.position, deathPoint.rotation);
            Instantiate(coinPrefab, deathPoint.position, deathPoint.rotation);
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
