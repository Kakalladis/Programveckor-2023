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
    public Transform wallCheck1;
    public Transform wallCkeck2;
    bool isGrounded;
    bool isFree;
    bool isFree2;


    // Update is called once per frame
    void Update()
    {
        // Gå höger och vänster
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-2, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && isFree == false)
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
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && isFree == false && isFree2 == false)
        {
            rb2d.AddForce(new Vector3(0, 1, 0) * jumpforce);
        }

        if (speed >= 10)
        {
            speed = 10;
        }


        // Kollar om spelaren är på marken för att kunna hoppa igen
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.97f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        isFree = Physics2D.OverlapCapsule(wallCheck1.position, new Vector2(0.006f, 0.34f), CapsuleDirection2D.Vertical, 0, groundLayer);
        isFree2 = Physics2D.OverlapCapsule(wallCkeck2.position, new Vector2(0.03f, 0.34f), CapsuleDirection2D.Vertical, 0, groundLayer);
    }
}
