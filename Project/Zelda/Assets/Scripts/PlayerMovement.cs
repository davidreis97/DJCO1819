using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;

    public PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = PlayerState.walk;

        // player facing down in the begining 
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");  // GetAxis
        change.y = Input.GetAxisRaw("Vertical");    // dows not interpolate the values - no accelaration
                                                    // Debug.Log(change);

        // not already attacking or in stager state
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }

        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            UpdateAnimationAndMove();
        }

    }


    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;

        yield return null;  //wait 1 frame

        animator.SetBool("attacking", false);

        yield return new WaitForSeconds(.3f);

        // reset state
        currentState = PlayerState.walk;
    }


    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        // normalize vector - diagonal walking
        change.Normalize();

        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }


    public void Knock(float knockTime)
    {
        currentState = PlayerState.stagger;
        StartCoroutine(KnockCo(knockTime));
    }

    IEnumerator KnockCo(float knockTime)
    {
        yield return new WaitForSeconds(knockTime);
        myRigidbody.velocity = Vector2.zero;

        currentState = PlayerState.idle;
         
    }
}
