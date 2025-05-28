using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KangFuryManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    private bool started = false;
    private bool levelCompleted = false;

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
        slider.maxValue = 88;
        slider.value = 44;
    }

    void Update()
    {
        /*if (!startPlaying && !started)
        {
            StartMusic();
            started = true;
        }*/

        if (slider.value == 0 && !levelCompleted)
        {
            levelCompleted = true;
            theBS.gameObject.SetActive(false);
            FinishLevel();
        }

        if (hitStreak == 4)
        {
            Debug.Log("4 note hit streak!");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            hitStreak = 0;
        }

        if (enemyHitStreak == 4)
        {
            Debug.Log("4 note enemy hit streak!");
            enemyAnimator.SetTrigger("Streak");
            Instantiate(notesFX, notePoint.position, notePoint.rotation);
            enemyHitStreak = 0;
        }

        if (enemyScore >= 44)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (levelCompleted)
        {
            Debug.Log("You have defeated Kang Fury");

        }
    }

    public void StartMusic()
    {
        if (!startPlaying)
        {
            startPlaying = true;
            theBS.hasStarted = true;
            theMusic.Play();
        }
    }

    public void UpdateSlider(bool isEnemy)
    {
        if (isEnemy)
        {
            slider.value += 1;
        }
        else
        {
            slider.value -= 1;
        }
    }

    public void FinishLevel()
    {
        // Optional: Add any non-dialogue logic for level finish here
    }

}
