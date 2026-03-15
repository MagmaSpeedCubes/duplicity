using UnityEngine;

using MagmaLabs;
[CreateAssetMenu(fileName = "Activity", menuName = "Scriptable Objects/Activity")]
public class Activity : ScriptableObject
{
    public string name, id;
    public string description;

    public SerializableDictionary<RiskFactor, float> acceptEffects;
    public SerializableDictionary<RiskFactor, float> declineEffects;
    public SerializableDictionary<Outcome, float> outcomes;

    //public float timeCommitment;
    public AnimationCurve timeRewardCurve;
    public Range<float> timeRange;
}

[System.Serializable]
public struct Outcome
{
    public string name, id;
    public string description;
    public SerializableDictionary<RiskFactor, float> effects;
}
