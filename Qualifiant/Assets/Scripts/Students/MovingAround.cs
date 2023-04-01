using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Students
{
    public class MovingAround : MonoBehaviour
    {
        public Transform target;
        
        [SerializeField] private bool _isMoving = true;
        public Vector3 originPosition { get; private set; }
        public Vector3 targetPosition { get; private set; }

        public float range = 10;
        public float speed = 2;
        public float waitingTime = 2;
        
        private float _time = 0;
        private float _distance;

        public bool isMoving
        {
            get => _isMoving;
            set => _isMoving = value;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(target.position, range);
            Gizmos.DrawLine(originPosition, targetPosition);
        }

        private void Start()
        {
            ResetTargetPosition();
        }

        private void Update()
        {
            Vector3 position = target.position;

            if (Vector2.Distance(targetPosition, position) < 0.001f)
            {
                ResetTargetPosition();
            }
            
            if (_isMoving)
            {
                MoveAround();
            }
        }

        private void MoveAround()
        {
            _time += Time.deltaTime * speed;
            target.position = Vector3.Lerp(originPosition, targetPosition, _time / (_distance / speed));
        }

        public void ResetTargetPosition()
        {
            _time = 0;
            originPosition = target.position;

            do
            {
                targetPosition = (Vector3)(Random.insideUnitCircle * range) + originPosition;
            } while (!ClassRoom.Singleton.isInsideBoundaries(targetPosition));
                
            
            _distance = Vector3.Distance(originPosition, targetPosition);

            StartCoroutine(WaitBeforeMoving());
        }

        private IEnumerator WaitBeforeMoving()
        {
            _isMoving = false;
            float timeToWait = Random.Range(0, waitingTime);

            yield return new WaitForSeconds(timeToWait);

            _isMoving = true;
        }
    }
}