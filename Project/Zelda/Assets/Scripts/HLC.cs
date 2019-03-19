using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLC : MonoBehaviour
{
    public GameObject Target;
    public GameObject Bullet;
    public float speed;
    public float bulletSpeed;
    public float minDistance;
    public float shootingTimeout;
    public bool bulletFollowPlayer;
    private float currShootingTimeout;
    private SpriteRenderer sr;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        currShootingTimeout = shootingTimeout;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
 
        Vector3 vec = Target.transform.position - transform.position;

        if (vec.x < 0)
        {
            sr.flipX = true;
        }else{
            sr.flipX = false;
        }

        if ((Target.transform.position - gameObject.transform.position).magnitude > minDistance)
        {
            transform.position += vec.normalized * speed;
        }

        currShootingTimeout--;
        if(currShootingTimeout < 0)
        {
            Debug.Log("Shoot!");
            currShootingTimeout = shootingTimeout;
            GameObject bullet = Instantiate(Bullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Fireball>().speed = bulletSpeed;
            bullet.GetComponent<Fireball>().Target = Target;
            bullet.GetComponent<Fireball>().followTarget = bulletFollowPlayer;
        }
    }

    public void TakeHit(int hit)
    {
        health -= hit;
        if(health <= 0)
        {
            if (gameObject.name.Equals("Souto"))
            {
                this.enabled = false;
                GetComponent<HistoryTrigger>().enabled = true;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
