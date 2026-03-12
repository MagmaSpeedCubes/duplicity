
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using MagmaLabs.UI;
using MagmaLabs;

public class ControlPanelOnOffSwitch : ControlPanelInputBase
{
    [SerializeField] private Button button;
    [SerializeField] private Image light;
    [SerializeField] private Color onColor, offColor;
    [SerializeField] private bool isOn = false;


    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        UpdateVisuals();
    }
    void OnButtonClicked()
    {
        if(!operable) return;
        isOn = !isOn;
        UpdateVisuals();
        OnValueChanged.Invoke(isOn?1f:0f);
    }
    void UpdateVisuals()
    {
        light.color = isOn ? onColor : offColor;
    }
}
