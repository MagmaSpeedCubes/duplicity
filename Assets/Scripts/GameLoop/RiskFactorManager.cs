using System;

using UnityEngine;

using MagmaLabs;
using MagmaLabs.UI;


public class RiskFactorController : MonoBehaviour
{
    public static RiskFactorController instance;
    [SerializeField]private SerializableDictionary<RiskFactor, BarInfographicNeo>infographics;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            Debug.LogWarning("Multiple instances of RiskFactorManager detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    
    }

    public void LoadStartingConfiguration(StageConfig cfg)
    {
       
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
             
            //RiskFactor factor = (RiskFactor)name;
            BarInfographicNeo bin = infographics.Get(factor);
            RiskFactorConfig rfc = cfg.riskFactorConfigs.Get(factor);

            bin.SetValue(rfc.startingValue);
            bin.SetTargetValue(rfc.targetValue);

        }

    }

    public void ModifyRiskFactorValue(RiskFactor factor, float amount)
    {
        BarInfographicNeo bin = infographics.Get(factor);

        bin.SetValue(bin.currentValue + amount);

    }
}
[System.Serializable]
public enum RiskFactor
{
    happiness,
    sleep,
    stress,
    gpa,
    prestige,
    achievement, 
    mentalHealth, 
    honor

}



// [System.Serializable]
// public struct RiskFactorGroup
// {
//     public float value;
//     public string name;
//     public string description;
//     public InfographicBase infographic;
// }

