using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpforce;
    [SerializeField] public float fallMultiplier;
    [SerializeField] public float jumpMultiplier;
    [SerializeField] public float jumpTime;
    public Rigidbody2D rb2d;

    bool isJumping;
    float jumpCounter;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    void Update()
    {
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
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
            isJumping = true;
            jumpCounter = 0;
        }

        if (rb2d.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            rb2d.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.6f);
            }
        }

        // Kollar om spelaren är på marken för att kunna hoppa igen
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.7f, 0.18f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-speed, 0), ForceMode2D.Impulse);
        }
    }
}
