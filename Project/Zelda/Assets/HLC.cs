using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLC : MonoBehaviour
{
    public GameObject Target;
    public GameObject Bullet;
    public float speed;
    public float minDistance;
    public float shootingTimeout;
    private float currShootingTimeout;
    private SpriteRenderer sr;

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
            bullet.GetComponent<Fireball>().Target = Target;
        }
    }


}
