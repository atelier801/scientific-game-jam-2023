using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Transform root;
        
        public bool isOpen => root.gameObject.activeSelf;
        
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Space))
            {
                ToggleMenu();
            }
        }

        public void ToggleMenu()
        {
            root.gameObject.SetActive(!root.gameObject.activeSelf);
        }

        public void Retry()
        {
            SceneManager.LoadScene(0);
        }

        public void QuiteApp()
        {
            Application.Quit();
        }
    }
}