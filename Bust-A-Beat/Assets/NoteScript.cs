using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress)){
            if (canBePressed)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("arrow"))
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Contains("arrow"))
        {
            canBePressed = false;
        }
    }
}
