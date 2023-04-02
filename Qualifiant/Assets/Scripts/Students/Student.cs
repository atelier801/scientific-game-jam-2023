    using System;
using Students.Data;
using Students.Orientation;
    using UI;
    using UnityEngine;

namespace Students
{
    public class Student : MonoBehaviour
    {
        public StudentData data;

       
        
        public void Assign(OrientationType orientation)
        {
            Pupop.Singleton.SpawnPupop(data.GetFeedbackPupop(orientation));
            Destroy(gameObject);
        }
    }
}