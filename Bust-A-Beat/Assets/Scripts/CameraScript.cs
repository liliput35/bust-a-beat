using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // The object to follow
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Follow only the target's X position
        Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
