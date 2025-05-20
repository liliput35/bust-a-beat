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

    public DialogueTrigger levelCompleteDia;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public Transform notePoint;
    public GameObject notesFX;

    public int enemyScore = 0;
    public int score = 0;
    public Slider slider;
    public int hitStreak = 0;
    public int enemyHitStreak = 0;

    public Animator enemyAnimator;


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

        if (slider.value == 0 && !levelCompleted)
        {
            levelCompleted = true;
            if (levelCompleted)
            {
                theBS.gameObject.SetActive(false);
                FinishLevel();
            }
        }

        if (hitStreak == 4)
        {
            Debug.Log("4 note hit streak!");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            hitStreak = 0;
        }

        if (enemyHitStreak == 4) {
            Debug.Log("4 note enemy hit streak!");
            enemyAnimator.SetTrigger("Streak");
            Instantiate(notesFX, notePoint.position, notePoint.rotation);


            enemyHitStreak = 0;
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
        //Debug.Log("player: " + score + " enemy: " + enemyScore);
        if (isEnemy) { 
            slider.value += 1;

        }else
        {
            slider.value -= 1;
        }
            
    }

    public void FinishLevel()
    {
        levelCompleteDia.TriggerDialogue();
    }

    
}
