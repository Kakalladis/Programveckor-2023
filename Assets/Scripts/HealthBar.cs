using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Gjord av Hampus
    public Slider slider;

    //best�mmer healthbarens max health value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //funktion f�r att best�mma healthbarens nuvarande v�rde
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
