using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour//Gjord av Anton
{
    

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

       
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
       
        enemy1Animator.SetTrigger("Enemy 1 Damage");

    }

  


    public void OnTriggerEnter2D(Collider2D collision)// gör skada on contact mot playern.
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
