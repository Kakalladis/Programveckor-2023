using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;
    public Enemy3 enemy3;

    [SerializeField] AudioSource turretDeath;

    public int energyGain = 1;
    public EnergyBar energyBar;
    public Animator enemy3Animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy3 = GetComponent<Enemy3>();
        energyBar = FindObjectOfType<EnergyBar>();
        enemyHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth == 0)
        {
            enemy3Animator.SetTrigger("Turret Die");
            GainEnergy(energyGain);
            enemy3.enabled = false;

            turretDeath.Play();

            Destroy(this.gameObject, 2f);
        }
    }

    public void GainEnergy(int energy)
    {
        energyBar.currentEnergy += energy;
        if (energyBar.currentEnergy >=- 10)
        {
            energyBar.SetEnergy(energyBar.currentEnergy);
        }
    }
}
