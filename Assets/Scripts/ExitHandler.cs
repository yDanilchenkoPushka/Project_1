using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ExitHandler : MonoBehaviour
    {
        public event Action OnExited; 

        [SerializeField]
        private Button _exitButton;

        public void Initialize() => 
            _exitButton.onClick.AddListener(OnClicked);

        public void DeInitialize() => 
            _exitButton.onClick.RemoveListener(OnClicked);

        private void OnClicked() => 
            OnExited?.Invoke();

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}