using System;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
public class CardController : MonoBehaviour
{


    [SerializeField]protected TextMeshProUGUI title;
    [SerializeField]protected Image image;
    [SerializeField]protected TextMeshProUGUI body;

    [SerializeField]protected GameObject cardPrefab;
    [SerializeField] private CardEvent cardEvent;
    protected virtual CardEvent CardEvent => cardEvent;
    [SerializeField]protected TextMeshProUGUI declineTokenText;

    void Awake()
    {
        Initialize();
    }
    virtual protected void Initialize()
    {
        if (CardEvent == null)
        {
            return;
        }

        image.sprite = CardEvent.icon;
        title.text = CardEvent.name;
        body.text = CardEvent.description;
        declineTokenText.text = "" + CardEvent.declineTokenCost;


    }

    public virtual void SetData(CardEvent data)
    {
        cardEvent = data;
        Initialize();
    }
    

    virtual public void OnAccept()
    {
        //do the accept thing
        AudioManager.instance.PlaySFX("click");
        GameObject gameCard = Instantiate(cardPrefab, gameObject.transform.parent);

        if (StageController.instance != null && StageController.instance.stageRuntime.phaseNumber == 1)
        {
            StageController.instance.stageRuntime.selectedCardsInDiscovery++;
        }

        Destroy(this.gameObject);
    }

    virtual public void OnDecline()
    {
        //do the decline thing
        AudioManager.instance.PlaySFX("click");
        Destroy(this.gameObject);
    }


}
