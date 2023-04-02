using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Students.Environment
{
    public class ClassRoom : MonoBehaviour
    {
        private static ClassRoom s_instance;

        public static ClassRoom Singleton
        {
            get
            {
                if (!s_instance) s_instance = FindObjectOfType<ClassRoom>();
                if (!s_instance) throw new NullReferenceException("Need one instance of ClassRoom in the sceen");
                return s_instance;
            }
        }

        public Vector2 boundaries = new (16,9);

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, (Vector3)boundaries + Vector3.forward);
        }
        
        public bool isInsideBoundaries(Vector2 point)
        {
            Vector2 pos = transform.position;

            return
                point.x > pos.x - boundaries.x / 2 &&
                point.x < pos.x + boundaries.x / 2 &&
                point.y > pos.y - boundaries.y / 2 &&
                point.y < pos.y + boundaries.y / 2;
        }

        public Vector2 GetRandomPointInBoundaries()
        {
            Vector3 pos = transform.position;
            
            return new Vector2
            {
                x = Random.Range(pos.x - boundaries.x / 2, pos.x + boundaries.x / 2),
                y = Random.Range(pos.y - boundaries.y / 2, pos.y + boundaries.y / 2)
            };
        }
    }
}