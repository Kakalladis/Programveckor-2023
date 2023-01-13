using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{

    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform projectileOffset;
    [SerializeField]
    float projectileCooldown;
    float timer;

    

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > projectileCooldown && Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectile, projectileOffset.position, projectileOffset.rotation);
            timer = 0;
        }

        print(timer);
    }
}