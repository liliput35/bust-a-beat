using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    public float speed = 5f;         // Speed of the bullet
    public float maxDistance = 5f;  // Distance after which the bullet is destroyed

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the bullet to the left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check distance traveled
        float distanceTravelled = Vector3.Distance(startPosition, transform.position);
        if (distanceTravelled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
