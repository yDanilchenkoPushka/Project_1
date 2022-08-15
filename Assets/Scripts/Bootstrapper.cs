using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private Button _startGameButton;
        
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = new SceneLoader();
            
            _startGameButton.onClick.AddListener(LoadLevel);
        }

        private void OnDisable() => 
            _startGameButton.onClick.RemoveListener(LoadLevel);

        private void LoadLevel() => 
            _sceneLoader.Load(SceneInfos.LEVEL);
    }
}