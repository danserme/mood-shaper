using UnityEngine;
using UnityEngine.UI;

public class ColorModifier : MonoBehaviour
{
    float m_Hue;
    float m_Saturation;
    float m_Value;
    public Slider m_SliderHue, m_SliderSaturation, m_SliderValue;
    public Renderer m_Renderer;

    void Start()
    {
        m_SliderHue.maxValue = 1;
        m_SliderSaturation.maxValue = 1;
        m_SliderValue.maxValue = 1;

        m_SliderHue.minValue = 0;
        m_SliderSaturation.minValue = 0;
        m_SliderValue.minValue = 0;
    }

    void Update()
    {
        m_Hue = m_SliderHue.value;
        m_Saturation = m_SliderSaturation.value;
        m_Value = m_SliderValue.value;
        m_Renderer.material.color = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);
    }
}

// [CreateAssetMenu()]
// public class ColorSet : ScriptableObject {
//     public Color meshColor;
// }
