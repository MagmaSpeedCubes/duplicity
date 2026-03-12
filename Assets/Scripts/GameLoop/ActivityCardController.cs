using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
public class ActivityCardController : MonoBehaviour
{
    [SerializeField]private Activity activity;

    [SerializeField]private TextMeshProUGUI title;
    [SerializeField]private TextMeshProUGUI body;
    [SerializeField]private Image image;

    void Awake()
    {
        string fullDescription = activity.description; 
        SerializableDictionary<RiskFactor, float> effects = activity.acceptEffects;
        
    }
    

    public void OnAccept()
    {
        SerializableDictionary<RiskFactor, float> effects = activity.acceptEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
             
            RiskFactorController.instance.ModifyRiskFactorValue(factor, effects.Get(factor));

        }
    }

    public void OnDecline()
    {
        SerializableDictionary<RiskFactor, float> effects = activity.declineEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
             
            RiskFactorController.instance.ModifyRiskFactorValue(factor, effects.Get(factor));

        }
    }
}
