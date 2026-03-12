using System.Collections;
using System.Collections.Generic;
using MagmaLabs;
using MagmaLabs.UI;
using UnityEngine;
using UnityEngine.Events;


public class StageController : MonoBehaviour
{

    int currentObjective = 0;

    public UnityEvent OnStageBegin;
    public UnityEvent OnStageEnd;

    public StageRuntime levelRuntime;

    
    public static StageController instance;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            levelRuntime = new StageRuntime();
            Debug.LogWarning("Multiple instances of StageController detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    
    }

    void Start()
    {
        
        //StartCoroutine(BeginStageCoroutine());
    }

    // IEnumerator BeginStageCoroutine()
    // {
    //     yield return null;
    //     AlertManager.instance.BroadcastAlert(levelObjective, 2);
    //     yield return new WaitForSeconds(2f);
    //     AudioManager.instance.PlayBGM("mainTheme");
    //     BeginStage();
    // }

    // public void BeginStage()
    // {

    //     OnStageBegin.Invoke();
    //     BeginObjective();//the level assumes there is at least one objecive
    // }

    // public void BeginObjective()
    // {

    //     Objective obj = objectives[currentObjective];
    //     if (obj.taskPoint != null)
    //     {
    //         obj.taskPoint.gameObject.SetActive(true);
    //         WaypointManager.instance.SetTarget(obj.taskPoint.transform);
    //     }

    //     if (!string.IsNullOrWhiteSpace(obj.description))
    //     {
    //         InGameHUDManager.instance.objectiveText.text = obj.description;
    //     }

    //     obj.OnObjectiveStarted?.Invoke();
    //     TryBroadcastAlert(obj.startAlert);
    //     TryBeginCutscene(obj.startCutscene);

    // }

    // public void OnObjectiveProgress(float completed, float total)
    // {
    //     InGameHUDManager.instance.DisplayProgress(completed, total);
    // }

    // public void OnObjectiveCompleted()
    // {
    //     Objective obj = objectives[currentObjective];
    //     if (!TryBroadcastAlert(obj.completionAlert) && !string.IsNullOrWhiteSpace(obj.completionMessage))
    //     {
    //         AlertManager.instance.BroadcastAlert(obj.completionMessage, 2f);
    //     }
    //     TryBeginCutscene(obj.completionCutscene);
    //     obj.OnObjectiveCompleted?.Invoke();


    //     currentObjective++;
    //     if(currentObjective >= objectives.Count)
    //     {
    //         OnStageClear.Invoke();
            
    //     }
    //     else
    //     {
    //         BeginObjective();
    //     }
    // }

    // public void EndCutscene()
    // {
    //     levelRuntime.levelState = StageState.Playing;
    // }

    // private bool TryBroadcastAlert(Objective.ObjectiveAlert alert)
    // {
    //     if (!alert.enabled)
    //     {
    //         return false;
    //     }

    //     string message = alert.message;
    //     if (string.IsNullOrWhiteSpace(message))
    //     {
    //         return false;
    //     }

    //     float duration = alert.duration <= 0f ? 2f : alert.duration;
    //     AlertManager.instance.BroadcastAlert(message, duration);
    //     return true;
    // }

    // private void TryBeginCutscene(Objective.ObjectiveCutscene cutscene)
    // {
    //     if (!cutscene.enabled)
    //     {
    //         return;
    //     }

    //     levelRuntime.levelState = StageState.InCutscene;
    //     cutscene.OnBegin?.Invoke();
    // }




}

[System.Serializable]
public struct StageRuntime
{

    public SerializableDictionary<RiskFactorGroup> riskFactors;

    public SerializableDictionary<Activity> activities;

    public StageConfig config;

}









