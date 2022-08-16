using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private ButtonBar _buttonBar;
        
        private Controls _controls;
        private SceneLoader _sceneLoader;
        private ExitHandler _exitHandler;

        private void Awake()
        {
            _controls = new Controls();
            _sceneLoader = new SceneLoader();
            _exitHandler = new ExitHandler();
            
            _buttonBar.Construct(_controls);
            
            Initialize();
        }

        private void Initialize()
        {
            _controls.MainMenu.Enable();
            
            InteractiveButton interactiveButton;
            
            if (_buttonBar.TryGetButton<StartGameButton>(out interactiveButton))
                interactiveButton.OnClicked += LoadLevel;
            
            if (_buttonBar.TryGetButton<ExitButton>(out interactiveButton))
                interactiveButton.OnClicked += Exit;
        }

        private void DeInitialize()
        {
            _controls.MainMenu.Disable();
            
            _buttonBar.DeInitialize();
            
            InteractiveButton interactiveButton;
            
            if (_buttonBar.TryGetButton<StartGameButton>(out interactiveButton))
                interactiveButton.OnClicked -= LoadLevel;
            
            if (_buttonBar.TryGetButton<ExitButton>(out interactiveButton))
                interactiveButton.OnClicked -= Exit;
        }

        private void OnDestroy() => 
            DeInitialize();

        private void LoadLevel() => 
            _sceneLoader.Load(SceneInfos.LEVEL);

        private void Exit() => 
            _exitHandler.Exit();
    }
}