using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(RectTransform))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Serializable]
    public class PointerEventDataEvent : UnityEvent<PointerEventData> { }

    [Header("Drag Settings")]
    [SerializeField] private float holdThresholdSeconds = 0.35f;
    [SerializeField] private bool bringToFrontOnDrag = true;

    [Header("Events")]
    public PointerEventDataEvent onHold;
    public PointerEventDataEvent onDrag;
    public PointerEventDataEvent onDrop;

    private RectTransform rectTransform;
    
    private CanvasGroup canvasGroup;
    private bool pointerDown;
    private bool holdFired;
    private bool dragging;
    private bool dropFired;
    private float pointerDownTime;
    private PointerEventData lastPointerEvent;
    private Transform originalParent;
    private Canvas canvas;

    public ItemSlot CurrentSlot { get; private set; }

    private void Awake()
    {
        EnsureReferences();
        ResolveCanvas();
    }

    private void OnEnable()
    {
        ResolveCanvas();
    }

    private void Update()
    {
        if (IsLockedInSlot())
        {
            return;
        }

        if (!pointerDown || holdFired || dragging)
        {
            return;
        }

        if (Time.unscaledTime - pointerDownTime >= holdThresholdSeconds)
        {
            holdFired = true;
            onHold.Invoke(lastPointerEvent);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!EnsureReferences())
        {
            return;
        }

        if (IsLockedInSlot())
        {
            return;
        }

        pointerDown = true;
        holdFired = false;
        dropFired = false;
        pointerDownTime = Time.unscaledTime;
        lastPointerEvent = eventData;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        lastPointerEvent = eventData;
        if (!dropFired && !dragging)
        {
            dropFired = true;
            onDrop.Invoke(eventData);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!EnsureReferences())
        {
            return;
        }

        if (IsLockedInSlot())
        {
            return;
        }

        dragging = true;
        lastPointerEvent = eventData;
        originalParent = transform.parent;

        if (CurrentSlot != null)
        {
            CurrentSlot.RemoveItem(this);
            CurrentSlot = null;
        }

        if (bringToFrontOnDrag)
        {
            transform.SetParent(originalParent, false);
            transform.SetAsLastSibling();
        }

        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!EnsureReferences())
        {
            return;
        }

        if (IsLockedInSlot() || !dragging)
        {
            return;
        }

        lastPointerEvent = eventData;
        onDrag.Invoke(eventData);

        if (canvas == null)
        {
            ResolveCanvas();
        }

        if (canvas == null)
        {
            return;
        }

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out var localPoint))
        {
            rectTransform.anchoredPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!EnsureReferences())
        {
            return;
        }

        if (IsLockedInSlot())
        {
            dragging = false;
            pointerDown = false;
            return;
        }

        dragging = false;
        pointerDown = false;
        lastPointerEvent = eventData;
        canvasGroup.blocksRaycasts = true;
        if (!dropFired)
        {
            dropFired = true;
            onDrop.Invoke(eventData);
        }
    }

    public void AssignToSlot(ItemSlot slot)
    {
        CurrentSlot = slot;
    }

    private bool IsLockedInSlot()
    {
        return CurrentSlot != null && CurrentSlot.locked;
    }

    private void ResolveCanvas()
    {
        var found = GetComponentInParent<Canvas>();
        canvas = found != null ? found.rootCanvas : null;
    }

    private bool EnsureReferences()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }

        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        if (rectTransform == null)
        {
            Debug.LogError($"{name} needs a RectTransform for DragDrop.", this);
            return false;
        }

        return true;
    }
}
