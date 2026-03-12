using UnityEngine;
using UnityEngine.Events;

public interface ControlPanelInput
{
    public UnityEvent<float> OnValueChanged { get; }
    public bool operable { get; }
}

public abstract class ControlPanelInputBase : MonoBehaviour, ControlPanelInput
{
    public UnityEvent<float> OnValueChanged { get; protected set; } = new UnityEvent<float>();
    public bool operable { get; protected set; } = true;
}
