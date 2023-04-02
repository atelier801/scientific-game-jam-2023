using System;
using Students.Orientation.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Students.Orientation
{
    public class OrientationPit : MonoBehaviour
    {
        public OrientationType orientationType;
        public int quota;
        public bool _isOpen { get; private set; } = true;
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI _orientationSign;
        [SerializeField] private TextMeshProUGUI _quotaSign;
        [Space] 
        [SerializeField] private UnityEvent<Student> _onStudentAssign;
        public UnityEvent<Student> onStudentAssign => _onStudentAssign;

        public void AsignStudent(Collider2D col)
        {
            if (_isOpen && col.attachedRigidbody.TryGetComponent(out Student student))
            {
                student.Assign(orientationType);

                quota--;
                _quotaSign.text = quota.ToString();
                
                _onStudentAssign.Invoke(student);

                if (quota == 0)
                    _isOpen = false;
            }
        }

        public void LoadPitData(OrientationLevelData.PitData pitData)
        {
            _orientationSign.text = orientationType switch
            {
                OrientationType.general => "Général",
                OrientationType.techniqueTransition => "Tech de Transition",
                OrientationType.techniqueQualifiant => "Tech de Qualification",
                OrientationType.pro => "Pro",
                _ => throw new ArgumentOutOfRangeException()
            };

            quota = pitData.quota;

            _quotaSign.text = quota.ToString();
        }
    }
}