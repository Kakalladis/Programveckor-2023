using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth, maxHealth = 3f;


    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        enemyHealth -= damageAmount;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
