using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;

    public int maxEnergy = 10;
    public int minEnergy = 0;
    public int currentEnergy;

    public EnergyBar energyBar;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
        currentEnergy = minEnergy;
        energyBar.SetMinEnergy(minEnergy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            GainEnergy(1);
            Destroy(gameObject);
        }
    }

    public void GainEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }
}
