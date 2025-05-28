using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderCut : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    // Update is called once per frame
    private void Update()
    {
        changeTime -= Time.deltaTime;

        if(changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void toScene()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
