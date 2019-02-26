using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}


public class Enemy : MonoBehaviour
{
    public EnemyState currentState;

    //health
    public FloatValue maxHealth;
    public float health;

    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    //does not override start in the log class
    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <=0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D myRigidBoy, float knockTime, float damage)
    {
        currentState = EnemyState.stagger;                      // update state
        StartCoroutine(KnockCo(myRigidBoy, knockTime));
        TakeDamage(damage);
    }

    IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
         yield return new WaitForSeconds(knockTime);
         myRigidBody.velocity = Vector2.zero;

         // updatestate
         currentState = EnemyState.idle;

    }
}
