using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject Target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.up = Target.transform.position - transform.position;
        transform.position += transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().Play("Explode");
    }

    private void ShutDown()
    {
        gameObject.SetActive(false);
    }
}
