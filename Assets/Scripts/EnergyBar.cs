using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
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
    public void SetMinEnergy(int energy)
    {
        slider.minValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;
        if (slider.value == 5f)
        {
            specialAttack.canShoot = true;
        }
    }
}
