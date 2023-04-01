using UnityEngine;

namespace Students.Data
{
    [CreateAssetMenu(fileName = "NewStudent", menuName = "Student")]
    public class StudentData : ScriptableObject
    {
        public Sprite sprite;
        [Space]
        public string nom;
        public string origineSo;
        public string aspiration;
        [Space]
        public GradesData notes;
        [Space] 
        [TextArea]
        public string appreciations;
    }
}
