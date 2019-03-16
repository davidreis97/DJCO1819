using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : Interactable
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            if (! dialogueManager.isOpen)
            {
                dialogueManager.StartDialogue(dialogue);

            }
            else
            {
                dialogueManager.DisplayNextSentence();
             
            }
        }

        if (dialogueManager.isOpen)
        {
            contextClue.SetActive(false);
        }
        else  
        {
            contextClue.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInRange = false;
            dialogueManager.EndDialogue();
            contextClue.SetActive(false);
        }
    }
}