using System.Collections;
using System.Collections.Generic;


using UnityEngine;



using MagmaLabs;

[CreateAssetMenu(fileName = "DialogueInteraction", menuName = "Dialogue/DialogueBlock")]
public class DialogueBlock : ScriptableObject
{
    public List<DialogueLine> dialogue;
    public SerializableDictionary<DialogueBlock> continuations;

}

[System.Serializable]
public class DialogueLine
{
    public int characterID;
    public string message;

}
