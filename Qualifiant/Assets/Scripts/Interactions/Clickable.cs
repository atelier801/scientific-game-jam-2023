using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class Clickable : MonoBehaviour
    {
        [Range(0, 2)] public int _triggeringMouseButton;
        [Space]

        [SerializeField] private UnityEvent _onMouseDown;
        [SerializeField] private UnityEvent _onMouseUp;

        public UnityEvent onMouseDown => _onMouseDown;

        public UnityEvent onMouseUp => _onMouseUp;

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(_triggeringMouseButton))
            {
                _onMouseDown.Invoke();
            }
        }

        private void OnMouseUp()
        {
            if (Input.GetMouseButtonUp(_triggeringMouseButton))
            {
                _onMouseUp.Invoke();
            }
        }
    }
}