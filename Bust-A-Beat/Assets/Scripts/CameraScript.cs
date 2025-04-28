using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // The object to follow
    public float smoothSpeed = 0.125f;
    public float minXThreshold = -17f; // The minimum X coordinate for the camera
    public float maxXThreshold = 17f;  // The maximum X coordinate for the camera

    void LateUpdate()
    {
        if (target != null) // Make sure there's a target assigned
        {
            // Calculate the desired X position, clamping it within the min and max thresholds
            float desiredX = Mathf.Clamp(target.position.x, minXThreshold, maxXThreshold);

            // Create the desired position vector
            Vector3 desiredPosition = new Vector3(desiredX, transform.position.y, transform.position.z);

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}