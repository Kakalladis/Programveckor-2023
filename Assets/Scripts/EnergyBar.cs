using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    //Gjord av Hampus
    public Slider slider;
    public int minEnergy = 0;
    public int currentEnergy;

    SpecialAttack specialAttack;

    private void Start()
    {
        specialAttack = FindObjectOfType<SpecialAttack>();
        currentEnergy = minEnergy;
        SetMinEnergy(minEnergy);
    }

    //Funktion för att göra sliderns value till 0 efter vapnet har skjutit eller spelet körs om
    public void SetMinEnergy(int energy)
    {
        slider.minValue = energy;
        slider.value = energy;
    }

    //Bestämma sliderns nuvarande värde
    public void SetEnergy(int energy)
    {
        slider.value = energy;
        if (slider.value == 10f)
        {
            specialAttack.canShoot = true;
        }
    }
}
