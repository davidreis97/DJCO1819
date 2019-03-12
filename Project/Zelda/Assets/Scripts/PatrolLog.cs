using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public float roundingDistance = 0.2f;

    // Update is called once per frame
    public override void CheckDistance()
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
            }
        }
        else if (distance > chaseRadius)
        {

            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime); //where to move

                //move to the goal
                ChangeAnim(temp - transform.position);  // amount of movement
                myRigidbody.MovePosition(temp);
            }
            else
            {
                if (currentPoint == path.Length - 1)
                {
                    currentPoint = 0;
                }
                else
                {
                    currentPoint++;
                }
            }

        }
    }


}