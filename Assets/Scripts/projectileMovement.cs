using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D projectile;
    bool facingRight = true;
    [SerializeField] int bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        projectile.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
