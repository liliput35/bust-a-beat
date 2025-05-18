using UnityEngine;

public class DeathFXScript : MonoBehaviour
{
    private float lifetime = 0.5f; // 5 frames at 10 FPS

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
