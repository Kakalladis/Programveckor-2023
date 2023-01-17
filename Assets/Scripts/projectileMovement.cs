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
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
