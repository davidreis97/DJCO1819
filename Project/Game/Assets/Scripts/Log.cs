using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
    public Transform target;
    public float chaseRadius;       //chase the player
    public float attackRadius;      // attack the player
    public Transform homePosition;  // start position
    private Rigidbody2D myRigidbody;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // only moving in the physics calls
    void FixedUpdate()
    {
        // distance lock - target
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= chaseRadius && distance > attackRadius) // chase but not attack radius
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); //where to move

                ChangeAnim(temp - transform.position);  // amount of movement
                myRigidbody.MovePosition(temp);

                // update the state
                currentState = EnemyState.walk;
                anim.SetBool("wakeUp", true);
            }
        }
        else if (distance > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }

 
    /**
     * Update the animation
     */
    void ChangeAnim(Vector3 movement)
    {
        Vector3 faceDirection = Vector3.Normalize(movement);
        anim.SetFloat("moveX", faceDirection.x);
        anim.SetFloat("moveY", faceDirection.y);
    }

}
