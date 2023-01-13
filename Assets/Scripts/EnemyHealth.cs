using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHealth, maxHealth = 3;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
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
            Destroy(gameObject);
        }
    }

}
