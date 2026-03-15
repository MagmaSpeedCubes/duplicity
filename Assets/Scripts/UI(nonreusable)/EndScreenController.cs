using System.Collections.Generic;


using UnityEngine;

using TMPro;

using MagmaLabs;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] private Canvas endScreen;
    [SerializeField] private SerializableDictionary<TextMeshPro> textObjects;
    [SerializeField] private AnimationTimelineElement[] timeline;


    void Awake()
    {
        endScreen.enabled = false;
    }

    public void SetText(string key, string newtext)
    {
        textObjects[key].text = newtext;
    }

    public void SetText(Dictionary<string, string> textDict)
    {
        foreach(KeyValuePair<string, string> kvp in textDict)
        {
            SetText(kvp.Key, kvp.Value);
        }
    }

    public void Display()
    {
        
    }
}

public struct AnimationTimelineElement
{
    public GameObject elemToAnimate;
    public AnimationCurve curve;
    public float animTime;
    public float holdTime;
}
