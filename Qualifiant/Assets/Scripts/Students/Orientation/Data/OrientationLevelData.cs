using System;
using UnityEngine;

namespace Students.Orientation.Data
{
    [CreateAssetMenu(fileName = "NewOrientationLevel", menuName = "Orientation Level")]
    public class OrientationLevelData : ScriptableObject
    {
        [Serializable]
        public struct PitData
        {
            [Min(0)] public int quota;
            public OrientationType orientationType;
        }

        public PitData[] pits;
    }
}