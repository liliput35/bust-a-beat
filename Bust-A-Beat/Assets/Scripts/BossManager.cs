using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    private bool started = false;


    private DialogueTrigger theTrigger;
    public DialogueManager dialogueManager;

    public int score = 0;
    public Slider slider;

    void Awake()
    {
        theTrigger = GetComponent<DialogueTrigger>();
        theTrigger.TriggerDialogue();

        
    }

    void Update()
    {
        if (!startPlaying && !started && dialogueManager.doneDialogue)
        {
            StartMusic();
            started = true; 
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

    public void UpdateSlider()
    {
        Debug.Log("called slider update" + score);
        slider.maxValue = 44;
        slider.value = 44 - score;
    }
}
