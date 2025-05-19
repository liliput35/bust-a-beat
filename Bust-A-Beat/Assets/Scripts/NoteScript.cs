using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public int playerScore;
    public BossManager bossManager;

    void Start()
    {
        bossManager = FindFirstObjectByType<BossManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)){
            if (canBePressed)
            {
                gameObject.SetActive(false);
                playerScore += 1;
                
                bossManager.score += 1;
                bossManager.UpdateSlider();
                

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
        if (collision.name.Contains("arrow"))
        {
            canBePressed = false;
        }
    }
}
