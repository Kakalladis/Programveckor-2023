using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Gjord av Hampus
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(5.5f, 2.5f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    //Kameran följer spelaren efter en delay
    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
