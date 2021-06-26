using UnityEngine;
using UnityEngine.UI;

public class ColorModifier : MonoBehaviour
{
    float Hue;
    float Saturation;
    float Value;
    public Slider SliderHue, SliderSaturation, SliderValue;
    // public Renderer m_Renderer;
    public Material material;

    void Start()
    {
        SliderHue.maxValue = 1;
        SliderSaturation.maxValue = 1;
        SliderValue.maxValue = 1;

        SliderHue.minValue = 0;
        SliderSaturation.minValue = 0;
        SliderValue.minValue = 0;
    }

    void Update()
    {
        Hue = SliderHue.value;
        Saturation = SliderSaturation.value;
        Value = SliderValue.value;
        material.color = Color.HSVToRGB(Hue, Saturation, Value);
        // m_Renderer.material.color = Color.HSVToRGB(Hue, Saturation, Value);
    }
}