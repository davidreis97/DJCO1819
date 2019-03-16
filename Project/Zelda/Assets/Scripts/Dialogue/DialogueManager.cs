using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    // Text references
    public Text nameText;
    public Text dialogueText;

    // Animator
    public Animator animator;

    // Dialogue
    public GameObject dialogueImage;

    //keep track of sentences
    private Queue<string> sentences;

    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        // active 
        dialogueImage.SetActive(true);
        dialogueImage.transform.GetChild(0).gameObject.SetActive(true);
        dialogueImage.transform.GetChild(1).gameObject.SetActive(true);
        dialogueImage.transform.GetChild(2).gameObject.SetActive(true);

    }

    public void StartDialogue(Dialogue dialogue)
    {
    
        animator.SetBool("isOpen", true);
        isOpen = true;

        nameText.text = dialogue.name;

        sentences.Clear();

        // Add the sentences of the dialog to the queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
   
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;

        //stop old coroutine
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        // loop through each character
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            //wait 1 frame
            yield return null;
        }
    }
 

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        isOpen = false;
    }
}
