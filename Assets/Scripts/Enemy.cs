using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;

    float timer;

    [SerializeField] float footstepInterval;

    AudioSource goombaWalk;


    public PlayerHealth playerHealth;
    public Animator enemy1Animator;

    public int damage = 1;


    

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        myRigidbody = GetComponent<Rigidbody2D>();
        timer = 0;
        goombaWalk = GetComponent<AudioSource>();
        

    }

   


    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;

        if (timer > footstepInterval)
        {
            goombaWalk.Play();
            timer = 0;
        }

        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        enemy1Animator.SetTrigger("Enemy 1 Damage");

    }

    public bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
