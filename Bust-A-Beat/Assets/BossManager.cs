using UnityEngine;

public class BossManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    private DialogueTrigger dialogueTrigger;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
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
