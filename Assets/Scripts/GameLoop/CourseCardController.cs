using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
public class EventCardController : MonoBehaviour
{
    [SerializeField]private Activity activity;

    [SerializeField]private TextMeshProUGUI title;
    [SerializeField]private TextMeshProUGUI body;
    [SerializeField]private Image image;

    [SerializeField]private GameObject cardPrefab;

    void Awake()
    {
        title.text = activity.name;

        string fullDescription = activity.description  + "\n"; 
        

        SerializableDictionary<RiskFactor, float> acceptEffects = activity.acceptEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
            if (acceptEffects.Get(factor) != 0f)
            {
                fullDescription += "" + acceptEffects.Get(factor) + " " + factor.ToString() + "\n";
            }
        }

        fullDescription += "Decline cost: \n";

        SerializableDictionary<RiskFactor, float> declineEffects = activity.declineEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
            if (declineEffects.Get(factor) != 0f)
            {
                fullDescription += "" + declineEffects.Get(factor) + " " + factor.ToString() + "\n";
            }
        }

        body.text = fullDescription;
        
    }
    

    public void OnAccept()
    {
        SerializableDictionary<RiskFactor, float> effects = activity.acceptEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
             
            RiskFactorController.instance.ModifyRiskFactorValue(factor, effects.Get(factor));

        }
        AudioManager.instance.PlaySFX("click");
        GameObject gameCard = Instantiate(cardPrefab, gameObject.transform.parent);


        Destroy(this.gameObject);
    }

    public void OnDecline()
    {
        SerializableDictionary<RiskFactor, float> effects = activity.declineEffects;
        foreach (RiskFactor factor in Enum.GetValues(typeof(RiskFactor)))
        {
             
            RiskFactorController.instance.ModifyRiskFactorValue(factor, effects.Get(factor));

        }
        AudioManager.instance.PlaySFX("click");
        Destroy(this.gameObject);
    }


}
