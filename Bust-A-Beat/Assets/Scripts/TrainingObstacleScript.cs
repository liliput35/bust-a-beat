using UnityEngine;

public class TrainingObstacleScript : MonoBehaviour
{
    [SerializeField] private TrainingScript trainingScript;
    private bool hasBeenUsed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenUsed && collision.gameObject.name == "Guni")
        {
            trainingScript.IncrementPlatformCount();
            hasBeenUsed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenUsed && collision.name == "Bullet(Clone)")
        {
            trainingScript.IncrementDummyCount();
            hasBeenUsed = true;
        }
    }
}
