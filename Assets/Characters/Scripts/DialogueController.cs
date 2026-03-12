using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using MagmaLabs;
using MagmaLabs.UI;
public class DialogueController : MonoBehaviour
{
    [SerializeField] private RectTransform dialogueBox;
    [SerializeField] private TextMeshProUGUI mainTitleBlock;
    [SerializeField] private TMPEnhanced mainTextBlock;
    
    [SerializeField] private DialogueBlock activeBlock;

    [SerializeField] private TextMeshProUGUI[] advanceButtonText;

    [SerializeField] private Image shirtImage, hairImage;
    private List<Character> characters;

    

    private int index = 0;

    void Start(){
        MouseClickManager.instance.OnLeftClick.AddListener(OnLeftClick);
        AdvanceLine();
    }

    public void SetCharacters(List<Character> newchars){
        characters = newchars;
    }

    public void SetActiveBlock(DialogueBlock newblock){
        activeBlock = newblock;
    }



    public void OnLeftClick(Vector2 screenPos, Vector3 worldPos){
        // Convert screen position to local position within the dialogue box
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dialogueBox, screenPos, null, out localPoint))
        {
            // Check if the local point is within the dialogue box's rect
            if (dialogueBox.rect.Contains(localPoint))
            {
                AdvanceLine();
            }
        }
    }

    

    public void BeginDialogue(DialogueBlock newBlock)
    {
        activeBlock = newBlock;
        index = 0;
        AdvanceLine();
    }

    public void AdvanceLine()
    {
        Debug.Log("Advancing dialogue line");
        // display next line of the current dialogue block
        if (activeBlock == null || activeBlock.dialogue == null || activeBlock.dialogue.Count == 0)
            return;

        // show current line
        mainTextBlock.SetHiddenText(activeBlock.dialogue[index].message);
        StartCoroutine(mainTextBlock.WriteOnNormalized(1, 1));

        int speakingCharacterID = activeBlock.dialogue[index].characterID;
        Character speakingCharacter = characters[speakingCharacterID];

        shirtImage.sprite = speakingCharacter.accessories.Get("shirt").sprites.ElementAt(0).value;
        hairImage.sprite = speakingCharacter.accessories.Get("hair").sprites.ElementAt(0).value;


        //Debug.Log("Message: " + activeBlock.dialogue[index].message);
        
        index++;

        // if we've reached or passed the last line, show continuation buttons
        if (index >= activeBlock.dialogue.Count)
        {
            ShowContinuationOptions();
        }
    }

    private void ShowContinuationOptions()
    {
        // clear all button texts first
        for (int i = 0; i < advanceButtonText.Length; i++)
        {
            advanceButtonText[i].text = string.Empty;
            advanceButtonText[i].transform.parent.gameObject.SetActive(false);
        }

        if (activeBlock == null || activeBlock.continuations == null || activeBlock.continuations.Count == 0)
        {
            // no continuations: conversation end
            EndDialogue();
            return;
        }

        int iIndex = 0;
        foreach (var kvp in activeBlock.continuations.Items)
        {
            if (iIndex >= advanceButtonText.Length){
                Debug.LogError("DialogueController does not have enough buttons to display all options");
                break; // not enough buttons
            }

            advanceButtonText[iIndex].text = kvp.key;
            advanceButtonText[iIndex].transform.parent.gameObject.SetActive(true);
            iIndex++;
        }
    }

    private void EndDialogue()
    {
        Destroy(dialogueBox.gameObject);
    }

    public void AdvanceDialogueBlock(int button)
    {
        if (activeBlock == null || activeBlock.continuations == null)
            return;

        if (button < 0 || button >= activeBlock.continuations.Count)
            return;

        // fetch block by index since dictionary
        var continuationList = activeBlock.continuations.Items;
        if (button >= continuationList.Count)
            return;

        DialogueBlock next = continuationList[button].value;
        if (next != null)
        {
            BeginDialogue(next);
            // immediately advance to first line
            AdvanceLine();
        }
        else
        {
            EndDialogue();
        }
    }


}
