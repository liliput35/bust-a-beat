using UnityEngine;

public class HeartUIController : MonoBehaviour
{
    public Animator heartAnimator;   // Animator controlling all heart visuals
    public PlayerScript player;      // Reference to PlayerScript
    public EnemyScript enemy;

    void Update()
    {
        if (player != null && heartAnimator != null)
        {
            heartAnimator.SetFloat("Health", player.currentHealth);
        }

        if (enemy != null && heartAnimator != null)
        {
            heartAnimator.SetFloat("Health", enemy.currentHealth);
        }
    }
}
