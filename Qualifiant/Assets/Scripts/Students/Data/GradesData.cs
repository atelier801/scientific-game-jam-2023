using System;
using UnityEngine;

namespace Students.Data
{
    [Serializable]
    public struct GradesData
    {
        [SerializeField] [Range(0, 20)] private float _sciences;
        [SerializeField] [Range(0, 20)] private float _maths;
        [SerializeField] [Range(0, 20)] private float _langues;
        [SerializeField] [Range(0, 20)] private float _français;
        [SerializeField] [Range(0, 20)] private float _histGeo;
        [SerializeField] [Range(0, 20)] private float _sport;

        public float sciences => _sciences;
        
        public float maths => _maths;

        public float langues => _langues;

        public float français => _français;

        public float histGeo => _histGeo;

        public float sport => _sport;

        public float moyenne => (_sciences + _langues + _français + _histGeo + _sport) / 5;
    }
}
