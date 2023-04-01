using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Interactions
{
    public class DragNDrop : MonoBehaviour
    {
        
        public bool isDragged { get; private set; }
        
        private Vector3 _dragOffset;
        
        [Header("This Component need a collider set as trigger")]
        [Space]
        [SerializeField] private UnityEvent _onDragBegin;
        [SerializeField] private UnityEvent _onDragEnds;

        public UnityEvent onDragBegin => _onDragBegin;
        public UnityEvent onDragEnds => _onDragEnds;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && isDragged)
            {
                OnMouseDragRelease();
            }
        }

        private void OnMouseDrag()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = transform.position;
            mousePos.z = pos.z;

            if (!isDragged)
            {
                isDragged = true;
                _onDragBegin.Invoke();
                _dragOffset = mousePos - pos;
            }

            transform.position = mousePos + _dragOffset;
        }

        private void OnMouseDragRelease()
        {
            isDragged = false;
            _onDragEnds.Invoke();
        }
    }
}