using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektDestroyOnCollision : MonoBehaviour
{
    //lucas �r skyldig f�r deta 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet")) // om spelarens skot tr�ffar 
        {
            Destroy(gameObject); // f�rst�r objekt
        }

    }
}
