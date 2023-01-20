using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;

    [SerializeField] AudioSource droneDeath;


    public int energyGain = 1;
    public EnergyBar energyBar;
    public Animator enemy2Animator;

    // Start is called before the first frame update
    void Start()
    {
        energyBar = FindObjectOfType<EnergyBar>();
        enemyHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        enemy2Animator.SetTrigger("Enemy 2 Damage");

        if (enemyHealth == 0)
        {
            enemy2Animator.SetBool("Enemy 2 Dead", true);
            enemy2Animator.SetTrigger("Enemy 2 Die");
            GainEnergy(energyGain);

            droneDeath.Play();

            Destroy(this.gameObject, 1f);
        }
    }

    public void GainEnergy(int energy)
    {
        energyBar.currentEnergy += energy;
        if (energyBar.currentEnergy >= -10)
        {
            energyBar.SetEnergy(energyBar.currentEnergy);
        }
    }
}
