using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float range;

    public Transform target;

    bool detected = false;

    Vector2 direction;

    public GameObject enemy3Projectile;

    public float fireRate;

    float nextTimeToFire=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 targetPos = target.position;

        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (detected==false)
                {
                    detected = true;
                    
                }
            }
            else
            {
                if (detected == true)
                {
                    detected = false;
                    
                }
            }
        }

        if (detected)
        {
            if(Time.time>nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
