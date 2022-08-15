using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private ExitHandler _exitHandler;
        
        [SerializeField]
        private Button _startGameButton;
        
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = new SceneLoader();
            
            _startGameButton.onClick.AddListener(LoadLevel);
            
            _exitHandler.Initialize();
            _exitHandler.OnExited += Exit;
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(LoadLevel);
            
            _exitHandler.DeInitialize();
            _exitHandler.OnExited -= Exit;
        }
        
        private void LoadLevel() => 
            _sceneLoader.Load(SceneInfos.LEVEL);

        private void Exit()
        {
            _exitHandler.DeInitialize();
            _exitHandler.Exit();
        }
    }
}