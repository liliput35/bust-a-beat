using UnityEngine;

public class MysteriousScript : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "Guni" && dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
