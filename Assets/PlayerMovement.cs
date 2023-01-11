using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] public float jumpforce = 1f;
    public Rigidbody2D rb2d;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;


    // Update is called once per frame
    void Update()
    {
        // Gå höger och vänster
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(2, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        // Hoppa
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb2d.AddForce(new Vector3(0, 1, 0) * jumpforce);
        }

        if (speed >= 10)
        {
            speed = 10;
        }


        // Kollar om spelaren är på marken för att kunna hoppa igen
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
