using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
<<<<<<< Updated upstream
    public int damage = 2;
    public float range = 6f;
=======
    //Gjord av Hampus

    public int damage = 3;
    public float range = 8f;
>>>>>>> Stashed changes
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public Transform player;
    public bool canShoot;
    EnergyBar energyBar;

    public float fadeOutSpeed = 1.0f;
    public float fadeInSpeed = 1.0f;
    private Color startColor;
    private Color endColor;
    private Color originalStartColor;
    private Color originalEndColor;


    void Start()
    {
        energyBar = FindObjectOfType<EnergyBar>();
        canShoot = false;

        originalStartColor = lineRenderer.startColor;
        originalEndColor = lineRenderer.endColor;
        startColor = originalStartColor;
        endColor = originalEndColor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canShoot)
        {
            StartCoroutine(Shoot());
            energyBar.SetEnergy(energyBar.minEnergy);
            energyBar.currentEnergy = energyBar.minEnergy;
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

            if (hit.transform.CompareTag("Enemy1"))
            {
                hit.transform.GetComponent<Enemy1Health>().TakeDamage(damage);
            }

            if (hit.transform.CompareTag("Enemy2"))
            {
                hit.transform.GetComponent<Enemy2Health>().TakeDamage(damage);
            }

            if (hit.transform.CompareTag("Enemy3"))
            {
                hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
        
        if (player.rotation == Quaternion.Euler(0, -180, 0))
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + new Vector3(-8, 0, 0));
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + new Vector3(8, 0, 0));
        }

        FadeIn();
        yield return new WaitForSeconds(1.5f);
        FadeOut();
    }

    public void FadeIn()
    {
        lineRenderer.enabled = true;
        lineRenderer.startColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        lineRenderer.endColor = new Color(endColor.r, endColor.g, endColor.b, 0);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (lineRenderer.startColor.a < 1.0f)
        {
            lineRenderer.startColor = Color.Lerp(lineRenderer.startColor, startColor, fadeInSpeed * Time.deltaTime);
            lineRenderer.endColor = Color.Lerp(lineRenderer.endColor, endColor, fadeInSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutEffect());
    }

    IEnumerator FadeOutEffect()
    {
        startColor = lineRenderer.startColor;
        endColor = lineRenderer.endColor;
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            startColor = lineRenderer.startColor;
            endColor = lineRenderer.endColor;
            lineRenderer.startColor = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0), elapsedTime);
            lineRenderer.endColor = Color.Lerp(endColor, new Color(endColor.r, endColor.g, endColor.b, 0), elapsedTime);
            elapsedTime += Time.deltaTime * fadeOutSpeed;
            yield return null;
            lineRenderer.startColor = originalStartColor;
            lineRenderer.endColor = originalEndColor;
        }
        lineRenderer.enabled = false;
    }
}
