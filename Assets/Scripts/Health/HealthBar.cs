using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void UpdateMaxHealth(int health)
    {
        slider.maxValue = health;
        

        fill.color = gradient.Evaluate(1f);

    }
    public void SetFillColor()
    {
        fill.GetComponent<Image>().color = new Color32(90, 100, 100, 255);
    }
    public void RevertFillColor()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
