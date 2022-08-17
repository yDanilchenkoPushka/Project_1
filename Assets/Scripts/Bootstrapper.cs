using CodeBase.Services;
using DefaultNamespace.UI;
using Rewired;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private ButtonBar _buttonBar;
        
        private SceneLoader _sceneLoader;
        private ExitHandler _exitHandler;

        private AllServices _services = new AllServices();

        private void Awake()
        {
            RegisterServices();
            
            _sceneLoader = new SceneLoader();
            _exitHandler = new ExitHandler();
            
            _buttonBar.Construct(_services.Single<ISimpleInput>());
            
            Initialize();
        }

        private void Initialize()
        {
            InteractiveButton interactiveButton;
            
            if (_buttonBar.TryGetButton<StartGameButton>(out interactiveButton))
                interactiveButton.OnClicked += LoadLevel;
            
            if (_buttonBar.TryGetButton<ExitButton>(out interactiveButton))
                interactiveButton.OnClicked += Exit;
        }

        private void DeInitialize()
        {
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

        private void RegisterServices()
        {
            _services.RegisterSingle<ISimpleInput>(InputService());
        }

        private ISimpleInput InputService() => 
            new RewiredInput(ReInput.players.GetPlayer(0));
    }
}