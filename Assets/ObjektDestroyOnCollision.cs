using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektDestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BlockFake1"))
        {
            Destroy(other.gameObject);
        }

    }
}
