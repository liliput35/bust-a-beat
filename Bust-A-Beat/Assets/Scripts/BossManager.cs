using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    private bool started = false;
    private bool levelCompleted = false;

    private DialogueTrigger theTrigger;
    public DialogueManager dialogueManager;

    public int enemyScore = 0;
    public int score = 0;
    public Slider slider;

    void Awake()
    {
        theTrigger = GetComponent<DialogueTrigger>();
        theTrigger.TriggerDialogue();

        slider.maxValue = 44;
        slider.value = 22;
    }

    void Update()
    {
        if (!startPlaying && !started && dialogueManager.doneDialogue)
        {
            StartMusic();
            started = true; 
        }

        if (score >= 22 && !levelCompleted)
        {
            levelCompleted = true;
            if (levelCompleted)
            {
                theBS.gameObject.SetActive(false);
                FinishLevel();
            }
        }

    }

    public void StartMusic()
    {
        if (!startPlaying )
        {
            
            startPlaying = true;
            theBS.hasStarted = true;

            theMusic.Play();
        }
    }

    public void UpdateSlider(bool isEnemy)
    {
        Debug.Log("player: " + score + " enemy: " + enemyScore);
        if (isEnemy) { 
            slider.value += 1;

        }else
        {
            slider.value -= 1;
        }
            
    }

    public void FinishLevel()
    {
        Debug.Log("Level completed. you took down mysterious strange");
    }
}
