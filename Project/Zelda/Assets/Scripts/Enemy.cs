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

    //speed
    public float moveSpeed = 1;

    //health
    public FloatValue maxHealth;
    public float health;

    //reference to death effect
    public GameObject deathEffect;

    //reference to heart object
    public GameObject heart;

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
            DeathEffect();
            MakePowerUp();
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

    /* Creates an animation for the enemy death */
    void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity); //last is rotation
            Destroy(effect, 1f);
        }
    }

    /* Creates powerups */
    void MakePowerUp()
    {
        int random = Random.Range(0, 3);

        switch (random)
        {

            default: // heart

                if (heart != null)
                {
                    Instantiate(heart, transform.position, Quaternion.identity);
                }
                break;
        }
    }
}
