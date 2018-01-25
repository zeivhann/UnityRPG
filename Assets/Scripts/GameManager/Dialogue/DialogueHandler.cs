using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public GameObject dialogueHandler;

    Dialogue dialogue;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        this.sentences = new Queue<string>();
        this.dialogue = Dialogue.instance;
	}

    public void StartDialogue(Dialogue dialogue)
    {
        // Show dialogue box
        this.dialogueHandler.SetActive(true);
        this.nameText.text = dialogue.name; 

        this.sentences.Clear();

        // Add each sentence to queue
        foreach(string sentence in dialogue.sentences)
        {
            this.sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (this.sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = this.sentences.Dequeue();
        // In case user starts next sentence before this one finishes, stop coroutines
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // append letters so they show up with a delay onto the screen
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");

        // Hide dialogue box
        this.dialogueHandler.SetActive(false);
    }
}
