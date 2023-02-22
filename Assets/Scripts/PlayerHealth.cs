using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Gjord av Hampus

    [SerializeField]
    AudioSource hurtSound;

    public int maxHealth = 10;
    public int currentHealth;
    public Animator animator;

    public HealthBar healthBar;

    public bool playGame;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = FindObjectOfType<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //ta damage + animationer
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

    // dö + animationer + ändra scen
    public void Die()
    {
        animator.SetBool("Is Dead", true);
        animator.SetTrigger("Die");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        print("Player Dead");
        
    }
}
