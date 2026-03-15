using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Serializable]
    public class DragDropEvent : UnityEvent<DragDrop> { }

    [Header("Events")]
    public DragDropEvent onItemDropped;
    public DragDropEvent onItemRemoved;

    [Header("Drop Filter")]

    public DragDrop CurrentItem { get; private set; }
    public bool locked = false;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var droppedObject = eventData.pointerDrag;
        if (droppedObject == null)
        {
            return;
        }

        var dragDrop = droppedObject.GetComponent<DragDrop>();
        if (dragDrop == null)
        {
            return;
        }

        if (!MeetsComponentRequirements(droppedObject))
        {
            return;
        }

        if (CurrentItem != null && CurrentItem != dragDrop)
        {
            RemoveItem(CurrentItem);
        }

        CurrentItem = dragDrop;
        dragDrop.AssignToSlot(this);
        SnapToSlot(dragDrop);
        onItemDropped.Invoke(dragDrop);
    }

    public void RemoveItem(DragDrop item)
    {
        if (CurrentItem != item)
        {
            return;
        }

        CurrentItem = null;
        onItemRemoved.Invoke(item);
    }

    virtual protected bool MeetsComponentRequirements(GameObject droppedObject)
    {
        return true;
    }

    private void SnapToSlot(DragDrop item)
    {
        var itemRect = item.GetComponent<RectTransform>();
        if (itemRect == null || rectTransform == null)
        {
            return;
        }

        // Keep current parent to avoid offset issues; snap using world position.
        itemRect.position = rectTransform.position;
    }


}
