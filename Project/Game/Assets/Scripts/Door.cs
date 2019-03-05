using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{

    public DoorType doorType;
    public bool open = false;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)   
        {
            // TODO check key
            if (doorType == DoorType.key)
            {
                Open();
            }
        
        }
    }


    public void Open()
    {
        // turn of the doors sprite renderer, and box collider
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Close()
    {
        doorSprite.enabled = true;
        open = false;
        physicsCollider.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
