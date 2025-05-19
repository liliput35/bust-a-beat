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

    public bool levelCompleted;

    public GameObject player;
    private Rigidbody2D playerRb;

    private bool hasMovedPlayer = false;

    public DialogueTrigger dialogueTrigger;


    public void IncrementPlatformCount()
    {
        platformsJumped++;

        if (platformsJumped <= 3)
        {
            UpdatePlatformText();
        } 

        CheckStatus();
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

        CheckStatus();
    }

    private void UpdateDummyText()
    {
        dummyCounterText.text = $"Shoot Dummies: {dummiesHit}/{totalDummies}";
    }

    private void CheckStatus(){
        if(dummiesHit >= totalDummies && platformsJumped >= totalPlatforms){
            levelCompleted = true;

            if(levelCompleted && !hasMovedPlayer){
                playerRb = player.GetComponent<Rigidbody2D>();
                playerRb.position = new Vector2(-19f, -1.05f);
                hasMovedPlayer = true;

                TriggerCompletedDialogue();
            }
        }


    }

    public void TriggerCompletedDialogue(){
        dialogueTrigger.TriggerDialogue();
    }
}
