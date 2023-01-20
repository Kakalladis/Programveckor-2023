using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject player;
    public Animator enemy2Animator;


    public GameObject enemyProjectile;
    public Transform eProjectileSpawnPoint;
    public GameObject enemyProjectilePrefab;
    public float enemyProjectileSpeed = 10;
    public GameObject enemy;

    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public bool facingRight = false;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {

       



        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;

            Shoot();
        }

        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }
        if (Detected)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.gameObject.transform.position.x, transform.position.y), Time.deltaTime * speed);

            if (Target.transform.position.x > gameObject.transform.position.x && facingRight)
                Flip();
            if (Target.transform.position.x < gameObject.transform.position.x && !facingRight)
                Flip();
        }
        


    }

    void Shoot()
    {
        enemy2Animator.SetTrigger("Enemy2 Attack");
        enemyProjectilePrefab = Instantiate(enemyProjectile, new Vector3(eProjectileSpawnPoint.transform.position.x, eProjectileSpawnPoint.transform.position.y, 0), eProjectileSpawnPoint.transform.rotation) as GameObject;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

}
