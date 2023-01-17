using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
      public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /* Vector2 targetPos = target.position;

         direction = targetPos - (Vector2)transform.position;

         RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

         if (rayInfo)
         {
             if (rayInfo.collider.gameObject.tag == "Player")
             {
                 if (detected==false)
                 {
                     detected = true;
                     AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;

                 }
             }
             else
             {
                 if (detected == true)
                 {
                     detected = false;
                     AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
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

         if(detected)
         {
             Throw.transform.up = direction;
         }*/
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }
        if (Detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        /*  GameObject enemy3ProjectileIns = Instantiate(enemy3Projectile, shootPoint.position, Quaternion.identity);
          enemy3ProjectileIns.GetComponent<Rigidbody2D>().AddForce(direction * force); */

        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);

    }

    /* private void OnDrawGizmosSelected()
     {
         Gizmos.DrawWireSphere(transform.position, range);
     }*/
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
