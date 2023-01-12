using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    public Rigidbody2D rb2d;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
    }
}
