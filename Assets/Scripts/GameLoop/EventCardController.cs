using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
public class EventCardController : CardController
{
    [SerializeField] private Event courseEvent;
        protected override CardEvent CardEvent => courseEvent;
    [SerializeField]private TextMeshProUGUI acceptStressText;
    [SerializeField]private TextMeshProUGUI acceptTokenText;

    override protected void Initialize()
    {
        base.Initialize();
        acceptStressText.text = ""+courseEvent.acceptStressCost;
        acceptTokenText.text = ""+courseEvent.acceptTokenReward;

    }

    public override void SetData(CardEvent data)
    {
        var casted = data as Event;
        if (casted == null)
        {
            Debug.LogError($"{name} expected Course data.", this);
            return;
        }

        courseEvent = casted;
        Initialize();
    }

    public override void OnAccept()
    {
        // GameObject newCard = Instantiate(cardPrefab, gameObject.transform.parent);

        // GameCard gameCard = newCard.GetComponent<GameCard>();
        // gameCard.SetImage(image.sprite);
        // gameCard.SetTitle(title.text);

        base.OnAccept();
    }

    
    




}
