
using System;
using Shapes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;

public class TouchToolsDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Disc disc;
    
    
    private Vector2 _bonkle;
    public Vector2 bonkle => _bonkle;
    private RectTransform rect;

    private Vector2 pressedPos;
    private Canvas topCanvas;
    private RectTransform topTransform;

    private float Ratio => topTransform.localScale.x;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        if(rect == null) Debug.LogError("No rect transform found");
        topCanvas = GetTopCanvas();
        topTransform = topCanvas.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressedPos = Map(eventData);
        _bonkle = Map(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _bonkle = Map(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var mapped = Map(eventData);
        
        _bonkle = mapped;
        
        var delta = mapped - pressedPos;
        
        // Debug.Log(disc.Radius);
        // Debug.Log(Ratio);
        // Debug.Log(delta.magnitude/Ratio);
        // Debug.Log(disc.Radius - delta.magnitude/Ratio);
        var z = Hutl.Map(delta.magnitude/Ratio, 0, disc.Radius, 0, 1);
        Debug.Log(z);
    }
    
    private Vector2 Map(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out var position);
            return position;
    }

    private Canvas GetTopCanvas()
    {
        Canvas[] c = GetComponentsInParent<Canvas>();
        return c[^1];
    }
}
