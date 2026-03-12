using UnityEngine;

using MagmaLabs.UI;


public class RiskFactorController : MonoBehaviour
{
    
}
[System.Serializable]
public enum RiskFactor
{
    happiness,
    sleep,
    stress,
    gpa,
    prestige,
    achievement 

}



[System.Serializable]
public struct RiskFactorGroup
{
    public RiskFactor factor;
    public float value;
    public string name;
    public string description;
    public InfographicBase infographic;
}