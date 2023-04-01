using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions
{
    public class Hover : MonoBehaviour
    {
        public Transform target;

        public bool isHovered { get; private set; }

        [SerializeField] private bool _isHoverable;
        [Space]
        [SerializeField] private UnityEvent _onHoverEnter;
        [SerializeField] private UnityEvent _onHoverExit;

        public bool isHoverable
        {
            get => _isHoverable;
            set
            {
                _isHoverable = value;
                isHovered = _isHoverable && isHovered;
            }
        }
        
        public UnityEvent onHoverEnter => _onHoverEnter;
        public UnityEvent onHoverExit => _onHoverExit;

        private void OnMouseEnter()
        {
            if (!_isHoverable)
                return;
            
            if (!isHovered)
            {
                isHovered = true;
                _onHoverEnter.Invoke();
            }
        }

        private void OnMouseExit()
        {
            if (!_isHoverable)
                return;
            
            if (isHovered)
            {
                isHovered = false;
                _onHoverExit.Invoke();
            }
        }
    }
}