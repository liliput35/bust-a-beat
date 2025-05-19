using UnityEngine;
using UnityEngine.UI;

public class TrainingScript : MonoBehaviour
{
    public Text platformCounterText;
    public Text dummyCounterText;

    private int platformsJumped = 0;
    private int dummiesHit = 0;

    private int totalDummies = 5;
    private int totalPlatforms = 3;

    public bool isCompleted;

    public GameObject player;
    private Rigidbody2D playerRb;
    private bool hasMovedPlayer = false;



    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(platformsJumped == totalPlatforms && dummiesHit == totalDummies && !hasMovedPlayer)
        {
            isCompleted = true;
        }

        if (isCompleted)
        {
            Debug.Log("Moving player with Rigidbody2D...");
            playerRb.position = new Vector2(-19f, -1.05f);
            hasMovedPlayer = true;

            isCompleted = false;
        }
    }

    public void IncrementPlatformCount()
    {
        platformsJumped++;

        if (platformsJumped <= 3)
        {
            UpdatePlatformText();
        }
    }

    private void UpdatePlatformText()
    {
        platformCounterText.text = $"Jump on Platforms: {platformsJumped}/{totalPlatforms}";
    }


    public void IncrementDummyCount()
    {
        dummiesHit++;

        if (dummiesHit <= 5)
        {
            UpdateDummyText();
        }
    }

    private void UpdateDummyText()
    {
        dummyCounterText.text = $"Shoot Dummies: {dummiesHit}/{totalDummies}";
    }
}
