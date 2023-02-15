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

    //Funktion som g�r att spelaren tar skada, spelar animation och �ndrar p� healthbar
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

    //Funktion f�r att d�da spelaren och spela animation + byta till main menu
    public void Die()
    {
        animator.SetBool("Is Dead", true);
        animator.SetTrigger("Die");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
