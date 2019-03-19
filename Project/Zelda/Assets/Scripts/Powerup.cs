using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    key,
    good,
    bad

}

public class Powerup : MonoBehaviour
{
    public Type powerupType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            Debug.Log(powerupType);
            switch (powerupType)
            {
                case Type.bad:
                    collision.GetComponent<PlayerHealth>().TakeHit(1);
                    break;
                case Type.good:
                    collision.GetComponent<PlayerHealth>().HealUp(1);
                    break;
                case Type.key:
                    GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().PlayerHasKey();
                    break;
                default:
                    break;
            }

            Destroy(this.gameObject);

        }
    }
}