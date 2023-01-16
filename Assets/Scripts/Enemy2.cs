using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        gameObject.transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.gameObject.transform.position.x, transform.position.y), Time.deltaTime * speed);
    }

   
}
