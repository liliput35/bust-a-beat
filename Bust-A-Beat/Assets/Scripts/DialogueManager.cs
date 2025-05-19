using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text dialogueText;
    public Text dialogueName;
    public Image portraitUI;
    private Queue<string> sentences;
    public bool isBoss = false;



    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) {

        dialogueName.text = dialogue.name;
        portraitUI.sprite = dialogue.portrait;

        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        animator.SetBool("isOpen", false);
        if (isBoss)
        {
            FindFirstObjectByType<BossManager>().StartMusic();
        }
    }

}
