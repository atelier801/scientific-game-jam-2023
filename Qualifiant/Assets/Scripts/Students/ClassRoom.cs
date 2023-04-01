using System;
using UnityEngine;

namespace Students
{
    public class ClassRoom : MonoBehaviour
    {
        private static ClassRoom s_instance;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, (Vector3)boundaries + Vector3.forward);
        }

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

        public bool isInsideBoundaries(Vector2 point)
        {
            Vector2 pos = transform.position;

            return
                point.x > pos.x - boundaries.x / 2 &&
                point.x < pos.x + boundaries.x / 2 &&
                point.y > pos.y - boundaries.y / 2 &&
                point.y < pos.y + boundaries.y / 2;
        }
    }
}