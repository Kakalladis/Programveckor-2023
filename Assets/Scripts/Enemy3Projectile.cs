using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Projectile : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3); 
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
