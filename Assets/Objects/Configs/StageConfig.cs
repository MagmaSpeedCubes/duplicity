using UnityEngine;
using MagmaLabs;
[CreateAssetMenu(fileName = "StageConfig", menuName = "Scriptable Objects/StageConfig")]
public class StageConfig : ScriptableObject
{
    public string name, id;
    [Multiline]public string description;

    public SerializableDictionary<RiskFactor, RiskFactorConfig> riskFactorConfigs;


}

[System.Serializable]
public struct RiskFactorConfig
{
    public float startingValue;
    public float targetValue;
    public AnimationCurve influenceCurve;
}
