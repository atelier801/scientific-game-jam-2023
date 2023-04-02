    using System;
using Students.Data;
using Students.Orientation;
using UnityEngine;

namespace Students
{
    public class Student : MonoBehaviour
    {
        public StudentData data;

        public void Assign(OrientationType orientation)
        {
            Destroy(gameObject);
        }
    }
}