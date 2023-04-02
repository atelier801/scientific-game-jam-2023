using System;
using Students.Orientation;
using UnityEngine;

namespace Students.Data
{
    [CreateAssetMenu(fileName = "NewStudent", menuName = "Student")]
    public class StudentData : ScriptableObject
    {
        [Serializable]
        public struct NarrativeOutcome
        {
            public OrientationType orientation;
            public RectTransform feedbackPupop;
        }

        [SerializeField] private NarrativeOutcome[] narratives;

        public RectTransform GetFeedbackPupop(OrientationType orientation)
        {
            foreach (var narrative in narratives)
            {
                if (narrative.orientation == orientation)
                    return narrative.feedbackPupop;
            }

            return null;
        }
    }
}
