using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBonk : MonoBehaviour
{

    public float speed;
    public float rayDist;
    private bool moveRight;
    public Transform groundDetect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);// går åt höger.
        RaycastHit2D wallCheck = Physics2D.Raycast(groundDetect.position, Vector2.right, rayDist);// Kollar om det finns mark under enemy.

        if (wallCheck.collider == true)//Vänder håll om platformen tar slut.
        {
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }
}
