using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(2f, 1f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}