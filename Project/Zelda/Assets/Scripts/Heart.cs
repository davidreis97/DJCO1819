using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite heartFull;
    public Sprite heartEmpty;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetFull()
    {
        GetComponent<SpriteRenderer>().sprite = heartFull;
    }

    public void SetEmpty()
    {
        GetComponent<SpriteRenderer>().sprite = heartEmpty;
    }
}
