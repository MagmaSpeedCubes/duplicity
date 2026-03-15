using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs.UI;
public class InGameHUDManager : MonoBehaviour
{
    [HideInInspector]public static InGameHUDManager instance;

    public TextMeshProUGUI timeText, advanceText, tokenText, phaseNameText, phaseNumberText;

    public TextMeshProUGUI currentStressText, tokensToAwardText;

    public List<InfographicBase> progressIndicators;
    public CanvasGroup progressIndicatorParent;


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


    void Update()
    {
        StageRuntime sr = StageController.instance.stageRuntime;
        timeText.text = "Week " + StageController.instance.stageRuntime.round;
        advanceText.text = ""+StageController.instance.stageRuntime.tokensToAdvance;
        tokenText.text = ""+StageController.instance.stageRuntime.prestigeTokens;

        phaseNameText.text = sr.phaseName;
        phaseNumberText.text = "Phase "+sr.phaseNumber;

        currentStressText.text = "" + sr.currentStress;
        tokensToAwardText.text = "" + sr.tokensToAward;
    }




    





}

