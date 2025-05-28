using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2Manager : MonoBehaviour
{
    public PlayerScript player;

    // Update is called once per frame

    void Update()
    {
        if (player.currentStacks == 11) {
            SceneManager.LoadScene("Level2Boss");
        }
    }
}
