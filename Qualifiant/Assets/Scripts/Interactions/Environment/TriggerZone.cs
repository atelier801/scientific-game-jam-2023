using System;
using UnityEngine;
using UnityEngine.Events;

namespace Interactions.Environment
{
    public class TriggerZone : MonoBehaviour
    {

        public LayerMask filter;
        [Space]
        
        [SerializeField] private UnityEvent<Collider2D> _onTriggerEnter;
        [SerializeField] private UnityEvent<Collider2D> _onTriggerExit;

        public UnityEvent<Collider2D> onTriggerEnter => _onTriggerEnter;
        public UnityEvent<Collider2D> onTriggerExit => _onTriggerExit;

        private void OnTriggerEnter2D(Collider2D col)
        {
            print(col.name);
            if ((filter.value & (1 << col.gameObject.layer)) != 0)
            {
                _onTriggerEnter.Invoke(col);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if ((filter.value & (1 << col.gameObject.layer)) != 0)
            {
                _onTriggerExit.Invoke(col);
            }
        }
    }
}