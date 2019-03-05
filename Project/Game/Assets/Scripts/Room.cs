using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Pot[] pots;

    // -- Text cenas
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    //camera
    public GameObject virtualCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger) {

            // set camera
            virtualCamera.SetActive(true);

            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }
 

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.SetActive(false);
        }
    }

 
    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);   // wait 4 seconds before disabling the text again
        text.SetActive(false);
    }
}

 