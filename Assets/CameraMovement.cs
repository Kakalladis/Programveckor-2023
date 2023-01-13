using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentPos.x = Player.transform.position.x + 4.5f;
        currentPos.y = Player.transform.position.y + 3.0f;
        currentPos.z = -10;
        transform.position = currentPos;
    }
}
