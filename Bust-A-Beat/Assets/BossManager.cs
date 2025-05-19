using UnityEngine;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public DialogueTrigger dialogueTrigger;

    void Start()
    {

        dialogueTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    public void StartMusic()
    {
        if (!startPlaying)
        {
            
            startPlaying = true;
            theBS.hasStarted = true;

            theMusic.Play();
        }
    }
}
