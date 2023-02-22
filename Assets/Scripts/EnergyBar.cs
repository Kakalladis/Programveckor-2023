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

    //g�r s� att energybaren b�rjar p� 0 n�r spelet startar
    public void SetMinEnergy(int energy)
    {
        slider.minValue = energy;
        slider.value = energy;
    }

    // updaterar barens v�rde
    public void SetEnergy(int energy)
    {
        slider.value = energy;
        if (slider.value == 5f)
        {
            specialAttack.canShoot = true;
        }
    }
}
