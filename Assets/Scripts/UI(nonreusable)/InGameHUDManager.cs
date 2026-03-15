using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs.UI;
public class InGameHUDManager : MonoBehaviour
{
    [HideInInspector]public static InGameHUDManager instance;

    public TextMeshProUGUI timeText, advanceText, tokenText;

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
        timeText.text = "Week " + StageController.instance.stageRuntime.round;
        advanceText.text = ""+StageController.instance.stageRuntime.tokensToAdvance;
        tokenText.text = ""+StageController.instance.stageRuntime.prestigeTokens;
    }




    





}

