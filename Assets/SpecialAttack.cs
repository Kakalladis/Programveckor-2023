using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public int damage = 2;
    public float range = 6f;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public Transform player;
    public bool canShoot;
    EnergyBar energyBar;

    void Start()
    {
        canShoot = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
            energyBar.SetEnergy(energyBar.minEnergy);
            canShoot = false;
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(firePoint.position, firePoint.right, range);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];

            if (hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
        
        if (player.rotation == Quaternion.Euler(0, -180, 0))
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + new Vector3(-6, 0, 0));
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + new Vector3(6, 0, 0));
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.2f);

        lineRenderer.enabled = false;
    }
}
