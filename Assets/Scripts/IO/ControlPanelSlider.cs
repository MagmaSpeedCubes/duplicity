
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using MagmaLabs.UI;
using MagmaLabs;
public class ControlPanelSlider : ControlPanelInputBase
{
    [SerializeField] private InfographicBase[] displays;
    [SerializeField] private Slider slider;


    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        foreach (var display in displays)
        {
            display.SetRange(slider.minValue, slider.maxValue);
            display.SetValue(slider.value);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        if(!operable) return;
        foreach (var display in displays)
        {
            display.SetValue(value);
        }
        OnValueChanged.Invoke(value);
    }



}
