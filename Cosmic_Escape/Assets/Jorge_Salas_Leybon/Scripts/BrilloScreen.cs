using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrilloScreen : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image PanelBrillo;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, slider.value);
    }

    public void ChangeSlider(float valor)
    {
        SliderValue = valor;
        PlayerPrefs.SetFloat("brillo", SliderValue);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, slider.value);
    }
}
