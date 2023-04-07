
using System;
using Shapes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UI;
using VectorTerrain.Scripts;

public class TouchToolsDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 _bonkle;
    public Vector2 bonkle => _bonkle;
    private Vector2 pressedPos;
    public Vector2 PressedPos => pressedPos;
    
    
    private RectTransform rect;
    private Canvas topCanvas;
    private RectTransform topTransform;

    public event Action<Vector2> Down;
    public event Action<Vector2> Up;
    public event Action<Vector2> Drag;
    public event Action<Vector2> Delta;
    
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
        var mapped = Map(eventData);
        pressedPos = mapped;
        _bonkle = mapped;
        Down?.Invoke(mapped);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var mapped = Map(eventData);
        _bonkle = mapped;
        Up?.Invoke(mapped);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var mapped = Map(eventData);
        _bonkle = mapped;
        var delta = mapped - pressedPos;
        // var z = Hutl.Map(delta.magnitude/Ratio, 0, disc.Radius, 0, 1);

        Drag?.Invoke(mapped);
        Delta?.Invoke(delta);
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
