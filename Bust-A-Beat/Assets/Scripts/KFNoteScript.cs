using UnityEngine;

public class KFNoteScript : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public int playerScore;
    public KangFuryManager bossManager;

    void Start()
    {
        bossManager = FindFirstObjectByType<KangFuryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (Input.GetKeyDown(keyToPress))
            {
                if (canBePressed)
                {
                    canBePressed = false; // Prevent trigger exit from firing after this
                    gameObject.SetActive(false);

                    playerScore += 1;
                    bossManager.score += 1;
                    bossManager.hitStreak += 1;
                    bossManager.enemyHitStreak = 0;
                    bossManager.UpdateSlider(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("arrow"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("arrow") && gameObject.activeSelf)
        {
            canBePressed = false;
            bossManager.enemyScore += 1;
            bossManager.hitStreak = 0;
            bossManager.enemyHitStreak += 1;
            bossManager.UpdateSlider(true);
        }
    }
}
