using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{//Gjord av Anton

    AudioSource turretShoot;
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
    public bool facingRight = false;
    

    // Start is called before the first frame update
    void Start()
    {
        turretShoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")//detectar playern.
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
        if (Detected)//Sjuter mot playern.
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
        if (Target.transform.position.x > gameObject.transform.position.x && facingRight)
            Flip();
        if (Target.transform.position.x < gameObject.transform.position.x && !facingRight)
            Flip();
    }

    void shoot()//Gör så att bullet åker mot player.
    {
        

        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        turretShoot.Play();

    }

    
    private void OnDrawGizmosSelected()// ger enemy en specifik range.
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }


    
   

    void Flip()//vänder på enemy om man går förbi.
    {
        
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
}
