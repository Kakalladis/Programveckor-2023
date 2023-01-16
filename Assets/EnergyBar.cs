using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public int minEnergy = 0;
    public int currentEnergy;

    public SpecialAttack specialAttack;

    private void Start()
    {
        currentEnergy = minEnergy;
        SetMinEnergy(minEnergy);
    }
    public void SetMinEnergy(int energy)
    {
        slider.minValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;
        if (slider.value == 10)
        {
            specialAttack.canShoot = true;
        }
    }
}
