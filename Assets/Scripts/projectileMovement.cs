using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectile;
    [SerializeField] int bulletSpeed;
    EnemyHealth enemyHealth;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        projectile.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy3")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy2")
        {
            collision.gameObject.GetComponent<Enemy2Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy1")
        {
            collision.gameObject.GetComponent<Enemy1Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            
        }
        else if (collision.gameObject.tag == "Bullet")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
