using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Gjord av Hampus
    public Slider slider;

    //bestämmer healthbarens max health value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //funktion för att bestämma healthbarens nuvarande värde
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
