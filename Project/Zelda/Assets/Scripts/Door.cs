using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    normal

}

public class Door : Interactable
{

    public DoorType doorType;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange )
        {

            if ( doorType == DoorType.normal || playerHealth.playerHasKey)
            {
                // Open door
                Destroy(transform.parent.gameObject);
            } 

        }
    }
 
 
}