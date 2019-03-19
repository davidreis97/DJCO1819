using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;    // force
    public float knockTime; // time

    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* Player; Breakable object */ 
        if (collision.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Pot>().Smash();
        }

        /* Enemy or Player */
        else if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag(collision.gameObject.tag))
            {
                return;
            }

            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                // calculate the difference 
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;    //normalize 

                // add force to the object
                hit.AddForce(difference, ForceMode2D.Impulse);

                // start knock back coroutine 
                // enemy
                if (collision.gameObject.CompareTag("enemy") && collision.isTrigger)   //  not the collision collider
                {  
                    collision.GetComponent<Enemy>().Knock(hit, knockTime, damage);          
                }

                if (collision.gameObject.name == "Souto" || collision.gameObject.name == "APR")
                {
                    collision.gameObject.GetComponent<HLC>().TakeHit(1);
                }

                // player
                else if (collision.gameObject.CompareTag("Player") && collision.isTrigger)
                {
                    collision.GetComponent<PlayerMovement>().Knock(knockTime);
                    collision.gameObject.GetComponent<PlayerHealth>().TakeHit(1);
                }
            }
        }
        else
        {
            Debug.Log("Something else");
        }
    }
 
}
