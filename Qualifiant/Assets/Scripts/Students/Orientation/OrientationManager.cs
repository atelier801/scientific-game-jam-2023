using System;
using Students.Orientation.Data;
using UnityEngine;

namespace Students.Orientation
{
    public class OrientationManager : MonoBehaviour
    {
        [SerializeField] private OrientationPit[] _pits;
        [SerializeField] private OrientationLevelData _levelData;
        [Space]
        public bool loadOnStart = true;

        private void Start()
        {
            if(loadOnStart) 
                LoadLevel();
        }

        public void LoadLevel()
        {
            if(!_levelData)
                Debug.LogWarning("no orientation level data to load in OrientationManager");
                
            foreach (var pit in _pits)
            {
                foreach (var pitData in _levelData.pits)
                {
                    if (pitData.orientationType == pit.orientationType)
                    {
                        pit.LoadPitData(pitData);
                        break;
                    }
                }
            }
        }
        
        public OrientationPit GetPit(OrientationType orientation)
        {
            foreach (var pit in _pits)
            {
                if (pit.orientationType == orientation)
                    return pit;
            }

            Debug.LogWarning("No OrientationPit with orientation : " + orientation);
            return null;
        }
    }
}