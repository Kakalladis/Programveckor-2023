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
    public LayerMask mask;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;// timer för att sjuta.


        if (timer > 1)
        {
            timer = 0;

            Shoot();



            Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        Debug.DrawRay(transform.position, Direction * Range);
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range,mask);
        if (rayInfo)
        {
            print(rayInfo.transform.name);
            if (rayInfo.collider.gameObject.tag == "Player")//detectar playern
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
           // flippar enmeny om man går förbi.

            if (Target.transform.position.x > gameObject.transform.position.x && facingRight)
                Flip();
            if (Target.transform.position.x < gameObject.transform.position.x && !facingRight)
                Flip();

           
            }
        }
        


    }

    void Shoot()//Sjuter neråt.
    {
        enemy2Animator.SetTrigger("Enemy2 Attack");
        enemyProjectilePrefab = Instantiate(enemyProjectile, new Vector3(eProjectileSpawnPoint.transform.position.x, eProjectileSpawnPoint.transform.position.y, 0), eProjectileSpawnPoint.transform.rotation) as GameObject;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);// ger range till enemy
    }

    void Flip()//Vänder på sig.
    {

        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

}
