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

    public StageRuntime stageRuntime;

    public StageConfig startingConfiguration;
    
    public static StageController instance;

    public UnityEvent nextPhase;
    private Coroutine phaseRoutine;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            
            Debug.LogWarning("Multiple instances of StageController detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
            stageRuntime = new StageRuntime(0);
            DontDestroyOnLoad(this.gameObject);
        }
    
    }

    void Start()
    {
        RiskFactorController.instance.LoadStartingConfiguration(startingConfiguration);
        BeginStage();
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

    public void BeginStage()
    {
        AudioManager.instance.PlayBGM("mainTheme");
        OnStageBegin.Invoke();
        
    }


    public void RunGameLoop()
    {

        /*
        Game loop consists of three phases
        Phase 1: Discovery - draw any number of cards, minimum 1
        Phase 2: Transition - accept or reject ALL cards
        Phase 3: Lock in - choose a few items to commit extra time to for prestige tokens

        Motivation for drawing cards: every card draw grants 2 prestige tokens
        */

        if (phaseRoutine != null)
        {
            StopCoroutine(phaseRoutine);
        }
        phaseRoutine = StartCoroutine(GameLoopSequence());
    }

    private IEnumerator GameLoopSequence()
    {
        BeginDiscoveryPhase();
        yield return WaitForNextPhase();

        BeginTransitionPhase();
        yield return WaitForNextPhase();

        BeginLockInPhase();
        // etc...
    }

    private IEnumerator WaitForNextPhase()
    {
        bool fired = false;
        UnityAction handler = () => fired = true;
        nextPhase.AddListener(handler);
        yield return new WaitUntil(() => fired);
        nextPhase.RemoveListener(handler);
    }

    public void BeginDiscoveryPhase()
    {
        
    }
    public void BeginTransitionPhase()
    {
        
    }

        public void BeginLockInPhase()
    {
        
    }


    public void DrawCard()
    {
        stageRuntime.cardsToDraw++;
    }

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

    public int prestigeTokens;
    public int round;
    public int tokensToAdvance;

    public int cardsToDraw;
    

    //public SerializableDictionary<RiskFactor, RiskFactorGroup> riskFactors;

    public SerializableDictionary<Activity> activities;

    public StageConfig config;

    public StageRuntime(int startingTokens)
    {
        prestigeTokens = startingTokens;
        round = 1;
        tokensToAdvance = 1;
        cardsToDraw = 0;
        activities = new SerializableDictionary<Activity>();
        config = new StageConfig();
    }

}








