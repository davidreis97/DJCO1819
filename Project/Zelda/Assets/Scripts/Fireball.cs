using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject Target;
    public bool followTarget;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.up = Target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            transform.up = Target.transform.position - transform.position;
        }
        transform.position += transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Break();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().Play("Explode");
        Debug.Log(collision);
    }

    private void ShutDown()
    {
        gameObject.SetActive(false);
    }
}
