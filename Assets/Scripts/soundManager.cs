using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField]
    float slidervalue;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        audioSource.volume = 0.5f; //Sätter volymen på musiken till 0.5
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
