﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            collision.GetComponent<PlayerHealth>().HealUp(1);
            Destroy(this.gameObject);

        }
    }
}