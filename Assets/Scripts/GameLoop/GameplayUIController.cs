using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameplayUIController : MonoBehaviour
{

    [SerializeField]private GameObject cardPrefab;
    [SerializeField]private Transform cardParent;
    [SerializeField]private Transform uiCardParent;    
    [SerializeField]private int cardOffset = 25;


    [SerializeField]private GameObject ecCardUIPrefab;
    [SerializeField]private Extracurricular[] extracurricularCards;
    [SerializeField]private GameObject courseCardUIPrefab;
    [SerializeField]private Course[] courseCards;
    [SerializeField]private GameObject eventCardUIPrefab;
    [SerializeField]private Event[] eventCards;
    public static GameplayUIController instance;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogWarning("Multiple instances of InGameHUDManager detected. Destroying duplicate.");
            Destroy(this);
        }
    }
    public void DrawCardAnimation()
    {
        StageRuntime sr = StageController.instance.stageRuntime;
        GameObject newCard = Instantiate(cardPrefab, cardParent);

        newCard.transform.localPosition = new Vector3(sr.cardsToDraw * cardOffset, 0, 0);
    }

    public IEnumerator RevealCard()
    {
        Debug.Log("Revealing card");
        var availableTypes = new List<int>(3);
        if (extracurricularCards != null && extracurricularCards.Length > 0)
        {
            availableTypes.Add(0);
        }
        if (courseCards != null && courseCards.Length > 0)
        {
            availableTypes.Add(1);
        }
        if (eventCards != null && eventCards.Length > 0)
        {
            availableTypes.Add(2);
        }

        if (availableTypes.Count == 0)
        {
            yield break;
        }

        int typeIndex = availableTypes[Random.Range(0, availableTypes.Count)];

        GameObject prefabToSpawn;
        CardEvent chosenData;

        switch (typeIndex)
        {
            case 0:
                prefabToSpawn = ecCardUIPrefab;
                chosenData = extracurricularCards[Random.Range(0, extracurricularCards.Length)];
                break;
            case 1:
                prefabToSpawn = courseCardUIPrefab;
                chosenData = courseCards[Random.Range(0, courseCards.Length)];
                break;
            default:
                prefabToSpawn = eventCardUIPrefab;
                chosenData = eventCards[Random.Range(0, eventCards.Length)];
                break;
        }

        if (prefabToSpawn == null || chosenData == null)
        {
            yield break;
        }

        GameObject newCard = Instantiate(prefabToSpawn, uiCardParent);
        var controller = newCard.GetComponent<CardController>();
        if (controller != null)
        {
            controller.SetData(chosenData);
        }

        yield return null;
    }
}
