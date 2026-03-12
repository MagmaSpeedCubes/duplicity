using System;
using System.Collections.Generic;

using UnityEngine;

using MagmaLabs;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]private Canvas canvas;
    [SerializeField]private GameObject dialogueBoxPrefab;

    [SerializeField]private List<DialogueBlock> startingBlocks;


    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Multiple instances of DialogueManager detected. Destroying duplicate.");
        }
        else
        {
            instance = this;
        }
    }

    public void GenerateDialogue(List<Character> characters)
    {
        GameObject newBox = Instantiate(dialogueBoxPrefab, canvas.gameObject.transform);
        DialogueController dc = newBox.GetComponent<DialogueController>();
        dc.SetCharacters(characters);

        System.Random r = new System.Random();        
        dc.SetActiveBlock(startingBlocks[r.Next(0, startingBlocks.Count)]);


    }

}