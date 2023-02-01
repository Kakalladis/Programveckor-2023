using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Projectile : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public GameObject Player;
    Rigidbody2D rb;
    public float force;

    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot+90);
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
