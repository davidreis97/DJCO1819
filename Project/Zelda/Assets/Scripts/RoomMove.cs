using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    // -- Text cenas
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player is in the trigger zone
        if (collision.CompareTag("Player"))
        {
            // change the camera offset
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;

            // update player position
            collision.transform.position += playerChange;


            // Text
            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    // can have a wait time - run in parallel with other processes  
    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);   // wait 4 seconds before disabling the text again
        text.SetActive(false);
    }
}
