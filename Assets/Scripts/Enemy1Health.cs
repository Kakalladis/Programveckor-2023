using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;

    public int energyGain = 1;
    public EnergyBar energyBar;
    public Animator enemy1Animator;

    // Start is called before the first frame update
    void Start()
    {
        energyBar = FindObjectOfType<EnergyBar>();
        enemyHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        enemy1Animator.SetBool("Enemy 1 Damage Is Animating", true);
        enemy1Animator.SetTrigger("Enemy 1 Damage");
        StartCoroutine(Wait());
        enemyHealth -= damageAmount;

        if (enemyHealth == 0)
        {
            enemy1Animator.SetBool("Enemy 1 Dead", true);
            enemy1Animator.SetTrigger("Enemy 1 Die");
            GainEnergy(energyGain);

            Destroy(this.gameObject, 1f);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        enemy1Animator.SetBool("Enemy 1 Damage Is Animating", false);
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
