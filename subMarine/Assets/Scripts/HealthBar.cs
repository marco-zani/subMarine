using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Text text;

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        setHealth(health);
    }

    public void setHealth(float health)
    {
        slider.value = health;
        text.text = health + "";
    }
}
