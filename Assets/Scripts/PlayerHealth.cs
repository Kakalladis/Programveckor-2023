using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    AudioSource hurtSound;

    public int maxHealth = 10;
    public int currentHealth;
    public Animator animator;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Take Damage");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        hurtSound.Play(0);


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Is Dead", true);
        animator.SetTrigger("Die");
        print("Player Dead");
    }
}
