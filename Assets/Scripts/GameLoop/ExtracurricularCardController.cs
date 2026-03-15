using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
public class ExtracurricularCardController : CardController
{
    [SerializeField] private Extracurricular ecEvent;
        protected override CardEvent CardEvent => ecEvent;

    [SerializeField]private TextMeshProUGUI acceptRecurringStressText;
    [SerializeField]private TextMeshProUGUI acceptRecurringTokenText;
    


    
    override protected void Initialize()
    {
        base.Initialize();
        acceptRecurringStressText.text = ""+ecEvent.acceptRecurringStressCost;
        acceptRecurringTokenText.text = ""+ecEvent.acceptRecurringTokenReward;

    }

    public override void SetData(CardEvent data)
    {
        var casted = data as Extracurricular;
        if (casted == null)
        {
            Debug.LogError($"{name} expected Extracurricular data.", this);
            return;
        }

        ecEvent = casted;
        Initialize();
    }

    
    override public void OnAccept()
    {
        GameObject newCard = Instantiate(cardPrefab, gameObject.transform.parent);

        ECCard gameCard = newCard.GetComponent<ECCard>();
        gameCard.SetImage(image.sprite);
        gameCard.SetTitle(title.text);
        gameCard.SetData(ecEvent);

        base.OnAccept();
    }


    




}
