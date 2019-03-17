using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sign : Interactable
{
    //Dialog box
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)   //GetKeyDown 1 frame only
        {
            // dialog box activated
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                contextClue.SetActive(true);    // active context clue

            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                contextClue.SetActive(false);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            playerInRange = false;
            dialogBox.SetActive(false);     // desactivate context clue

            contextClue.SetActive(false);
        }
    }


}