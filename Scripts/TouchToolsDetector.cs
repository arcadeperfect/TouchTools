
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class TouchToolsDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _bonkle;
    public Vector2 bonkle => _bonkle;
    private RectTransform rect;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        if(rect == null) Debug.LogError("No rect transform found");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _bonkle = Map(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _bonkle = Map(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _bonkle = Map(eventData);
    }
    private Vector2 Map(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out var position);
            return position;
    }
}
