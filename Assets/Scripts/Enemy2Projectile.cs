using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Projectile : MonoBehaviour
{

    public GameObject enemyProjectile;

    public PlayerHealth playerHealth;

    public int damage = 1;

     

    // Start is called before the first frame update
    void Start()
    {
       
        
            playerHealth = FindObjectOfType<PlayerHealth>();
        

    }

    private void Update()
    {
        transform.position += new Vector3(0, -5, 0) * Time.deltaTime;

        Destroy(this.gameObject, 2);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}

