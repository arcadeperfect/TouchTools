using System;
using UnityEngine;

namespace TouchTools.Scripts
{
    public class TouchHandler: MonoBehaviour
    {
        public TouchToolsDetector touchToolsDetector;
        public Transform bonkle;

        private void Update()
        {
            bonkle.position = touchToolsDetector.bonkle;
            Debug.DrawRay(touchToolsDetector.bonkle, Vector3.forward, Color.red);
        }
    }
}