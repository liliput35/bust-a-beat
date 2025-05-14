using UnityEngine;

public class MysteriousScript : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;
    private bool hasTriggered = false;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Guni" && dialogueTrigger != null && !hasTriggered)
        {
            Debug.Log("hit");
            dialogueTrigger.TriggerDialogue();
            hasTriggered = true;
        }
    }
}
