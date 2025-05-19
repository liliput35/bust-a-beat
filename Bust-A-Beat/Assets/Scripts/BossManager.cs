using UnityEngine;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    private bool started = false;


    private DialogueTrigger theTrigger;
    public DialogueManager dialogueManager;

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
}
