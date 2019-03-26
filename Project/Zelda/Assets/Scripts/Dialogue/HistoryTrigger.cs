using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HistoryTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    private bool aux = false;
    public PlayerMovement playerM;
    public bool triggerWin = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlaceHistoryCo());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   
        { 
            dialogueManager.DisplayNextSentence();
        }

        if (aux && !dialogueManager.isOpen)
        {
            if (triggerWin)
            {
                SceneManager.LoadScene("Win");
            }
            StartCoroutine(DeleteCo());
            
        } 
    }

    private IEnumerator PlaceHistoryCo()
    {
        yield return new WaitForSeconds(.5f);  
        dialogueManager.StartDialogue(dialogue);
        yield return new WaitForSeconds(.5f);
        aux = true;
    }

    private IEnumerator DeleteCo()
    {
        yield return null;
        playerM.canMove = true;
        Destroy(this.gameObject);
    }

}