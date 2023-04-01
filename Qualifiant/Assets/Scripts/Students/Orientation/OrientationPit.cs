using System;
using Students.Orientation.Data;
using TMPro;
using UnityEngine;

namespace Students.Orientation
{
    public class OrientationPit : MonoBehaviour
    {
        public OrientationType orientationType;
        public int quota;
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI _orientationSign;
        [SerializeField] private TextMeshProUGUI _quotaSign;
        public void AsignStudent(Collider2D col)
        {
            if (col.attachedRigidbody.TryGetComponent(out Student student))
            {
                student.Assign(orientationType);
            }
        }

        public void LoadPitData(OrientationLevelData.PitData pitData)
        {
            _orientationSign.text = orientationType switch
            {
                OrientationType.general => "Général",
                OrientationType.techniqueTransition => "Tech de Transition",
                OrientationType.techniqueQualifiant => "Tech de Qualification",
                OrientationType.pro => "Professionnel",
                _ => throw new ArgumentOutOfRangeException()
            };

            quota = pitData.quota;

            _quotaSign.text = quota.ToString();
        }
    }
}