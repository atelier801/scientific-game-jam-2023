using UnityEngine;

namespace Students
{
    [CreateAssetMenu(fileName = "NewStudent", menuName = "Student")]
    public class Student : ScriptableObject
    {
        public Sprite sprite;
        [Space]
        public string nom;
        public string origineSo;
        public string aspiration;
        [Space]
        public Grades notes;
        [Space] 
        public string appreciations;
    }
}
