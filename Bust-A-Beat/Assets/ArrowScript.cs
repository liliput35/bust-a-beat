using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultSprite;
    public Sprite isPressedSprite;

    public KeyCode keyToPress;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = isPressedSprite;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultSprite;
        }
    }
}
