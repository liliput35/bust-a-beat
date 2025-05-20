using UnityEngine;

public class NotesFXScript : MonoBehaviour
{
    public float moveSpeed = 2f;    // Units per second
    public float moveDistance = 1f; // Total distance to move up

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move upward
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Check if it has moved the desired distance
        float traveled = transform.position.y - startPosition.y;
        if (traveled >= moveDistance)
        {
            Destroy(gameObject);
        }
    }
}
