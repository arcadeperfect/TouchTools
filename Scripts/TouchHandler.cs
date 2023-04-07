using System;
using Shapes;
using UnityEngine;

namespace TouchTools.Scripts
{
    public class TouchHandler: MonoBehaviour
    {
        
        public Transform bonkle;
        public TouchToolsDetector detector;
        public Disc TouchRadiusDisc;

        public bool Bonkle = false;

        private RectTransform topTransform;
    
        private Canvas topCanvas;
        private float Ratio => topTransform.localScale.x;
        private void Start()
        {
            detector.Drag += OnDrag;
            detector.Down += OnDown;
            detector.Up += OnUp;
            detector.Delta += OnDelta;
            topCanvas = GetTopCanvas();
            topTransform = topCanvas.GetComponent<RectTransform>();
        }
        private void Update()
        {
            if(Bonkle) bonkle.position = detector.bonkle;
        }
        private void OnDelta(Vector2 pos)
        {
            var n = Normalize(pos);
        }
        private void OnDrag(Vector2 pos)
        {
        }
        private void OnDown(Vector2 pos)
        {
        }
        private void OnUp(Vector2 pos)
        {
        }
        private Canvas GetTopCanvas()
        {
            Canvas[] c = GetComponentsInParent<Canvas>();
            return c[^1];
        }
        private Vector2 Normalize(Vector2 dragged)
        {
            var x = Hutl.Map(dragged.x / Ratio, 0, TouchRadiusDisc.Radius, 0, 1);
            var y = Hutl.Map(dragged.y / Ratio, 0, TouchRadiusDisc.Radius, 0, 1);

            return new Vector2(x, y);
        }
    }
}