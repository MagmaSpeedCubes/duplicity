using UnityEngine;

public class ECCardSlot : ItemSlot
{
    void Start()
    {
        onItemDropped.AddListener(MoveSlotUp);
    }
    override protected bool MeetsComponentRequirements(GameObject droppedObject)
    {
        return droppedObject.GetComponent<ECCard>() != null;
    }

    
    public void MoveSlotUp(DragDrop dd)
    {
        locked = true;

        ECCard ecc = dd.gameObject.GetComponent<ECCard>();
        ecc.MoveSlotUp();
    }
}
