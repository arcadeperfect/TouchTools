using System.Collections;
using System.Collections.Generic;
using Shapes;
using UnityEngine;

public class TouchToolsManager : MonoBehaviour
{
    // public TouchToolsDetector detector;
    // public Disc TouchRadiusDisc;
    //
    // private RectTransform topTransform;
    //
    // private Canvas topCanvas;
    // private float Ratio => topTransform.localScale.x;
    //
    //
    // private void Start()
    // {
    //     detector.Drag += OnDrag;
    //     detector.Down += OnDown;
    //     detector.Up += OnUp;
    //     topCanvas = GetTopCanvas();
    //     topTransform = topCanvas.GetComponent<RectTransform>();
    // }
    //
    // private void OnDrag(Vector2 pos)
    // {
    //     Debug.Log(Normalize(pos));
    // }
    //
    // private void OnDown(Vector2 pos)
    // {
    //
    // }
    //
    // private void OnUp(Vector2 pos)
    // {
    // }
    //
    // private Canvas GetTopCanvas()
    // {
    //     Canvas[] c = GetComponentsInParent<Canvas>();
    //     return c[^1];
    // }
    //
    // private Vector2 Normalize(Vector2 dragged)
    // {
    //     var x = Hutl.Map(dragged.x / Ratio, 0, TouchRadiusDisc.Radius, 0, 1);
    //     var y = Hutl.Map(dragged.y / Ratio, 0, TouchRadiusDisc.Radius, 0, 1);
    //
    //     return new Vector2(x, y);
    // }

}
