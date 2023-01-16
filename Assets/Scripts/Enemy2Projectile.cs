using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Projectile : MonoBehaviour
{
    public GameObject enemyProjectile;

    public PlayerHealth playerHealth;

    public int damage = 1;

    // public float life = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position += new Vector3(0, -5, 0) * Time.deltaTime;
    }
    void Awake()
    {
        //Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            Destroy(enemyProjectile);

        }
        else
        {
            Destroy(enemyProjectile);
        }
    }
}

