using UnityEngine;
using UnityEngine.UI;

public class HeartUIController : MonoBehaviour
{
    public PlayerScript player;      // Reference to player
    public EnemyScript enemy;        // Reference to enemy

    public Image heartsUI;           // UI Image to display heart sprite

    public Sprite fiveHealth;
    public Sprite fourHealth;
    public Sprite threeHealth;
    public Sprite twoHealth;
    public Sprite oneHealth;
    public Sprite zeroHealth;

    public bool showPlayerHealth = true; // Toggle this to switch between player/enemy health UI

    void Update()
    {
        int currentHealth = showPlayerHealth ? player.currentHealth : enemy.currentHealth;
        UpdateHeartSprite(currentHealth);
    }

    void UpdateHeartSprite(int health)
    {
        switch (health)
        {
            case 5:
                heartsUI.sprite = fiveHealth;
                break;
            case 4:
                heartsUI.sprite = fourHealth;
                break;
            case 3:
                heartsUI.sprite = threeHealth;
                break;
            case 2:
                heartsUI.sprite = twoHealth;
                break;
            case 1:
                heartsUI.sprite = oneHealth;
                break;
            case 0:
            default:
                heartsUI.sprite = zeroHealth;
                break;
        }
    }
}
