using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject player;

    public GameObject enemyProjectile;
    public Transform eProjectileSpawnPoint;
    public GameObject enemyProjectilePrefab;
    public float enemyProjectileSpeed = 10;
    public GameObject enemy;

    

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.gameObject.transform.position.x, transform.position.y), Time.deltaTime * speed);



        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;

                Shoot();
        }

        
        

    }

    void Shoot()
    {
        
        enemyProjectilePrefab = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y, 0), enemy.transform.rotation) as GameObject;

    }
}
