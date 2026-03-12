using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs.UI;
public class InGameHUDManager : MonoBehaviour
{
    [HideInInspector]public static InGameHUDManager instance;

    public TextMeshProUGUI objectiveText;

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

    float displayInactiveTime = 0f;
    [SerializeField]private float hideDisplayThreshold = 0.5f;

    void Update()
    {
        displayInactiveTime += Time.deltaTime;
        if(displayInactiveTime >= hideDisplayThreshold)
        {
            progressIndicatorParent.alpha = 0f;
        }
    }

    public void DisplayProgress(float current, float total)
    {
        progressIndicatorParent.alpha = 1f;
        displayInactiveTime = 0f;

        int normalizedTotal = 100;
        int normalizedCurrent = (int) Mathf.Clamp(normalizedTotal * current/total, 0, normalizedTotal);

        foreach(InfographicBase infographic in progressIndicators)
        {
            infographic.SetRange(0, normalizedTotal);
            infographic.SetValue(normalizedCurrent);
        }

    }


    





}

