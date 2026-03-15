using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class ECCard : DragDrop

{
    [SerializeField]private Image image;
    [SerializeField]private TextMeshProUGUI title;

    [SerializeField]private ECCardSlot upper;
    public Extracurricular data;

    void Awake()
    {
        upper.enabled = false;
    }

    public void SetImage(Sprite spr)
    {
        image.sprite = spr;
    }

    public void SetTitle(string text)
    {
        title.text = text;
    }

    public void SetData(Extracurricular nd)
    {
        data = nd;
    }

    public void MoveSlotUp()
    {
        upper.enabled = true;
    }
}



