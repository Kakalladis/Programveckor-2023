using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;

    public int energyGain = 1;
    public EnergyBar energyBar;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            GainEnergy(energyGain);
            Destroy(gameObject);
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
