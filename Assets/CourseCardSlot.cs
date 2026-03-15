using UnityEngine;

public class CourseCardSlot : ItemSlot
{
    void Start()
    {
        onItemDropped.AddListener(MoveSlotUp);
    }
    override protected bool MeetsComponentRequirements(GameObject droppedObject)
    {
        return droppedObject.GetComponent<CourseCard>() != null;
    }



    
    public void MoveSlotUp(DragDrop dd)
    {
        locked = true;

        CourseCard cc = dd.gameObject.GetComponent<CourseCard>();
        cc.MoveSlotUp();
    }
}
