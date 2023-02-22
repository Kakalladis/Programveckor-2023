using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Gjord av Hampus

    public Slider slider;

    //g�r s� att man har fllt liv vid start av spelet
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //updatera barens v�rde
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
