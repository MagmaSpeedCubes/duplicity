using UnityEngine;

using MagmaLabs;
[CreateAssetMenu(fileName = "Activity", menuName = "Scriptable Objects/Activity")]
public class Activity : ScriptableObject
{
    public string name, id;
    public string description;

    public SerializableDictionary<RiskFactor, float> effects;
    public SerializableDictionary<Outcome, float> outcomes;

    //public float timeCommitment;
    public AnimationCurve timeRewardCurve;
}

[System.Serializable]
public struct Outcome
{
    public string name, id;
    public string description;
    public SerializableDictionary<RiskFactor, float> effects;
}
