using Data;
using Infrastructure.Processors.Tick;
using Services;
using Services.Input;
using Services.Scene;
using TMPro;
using UI.Bars;
using UI.Buttons;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _log;
        
        [SerializeField]
        private ButtonBar _buttonBar;

        [SerializeField]
        private DeviceBar _deviceBar;
        
        private ExitHandler _exitHandler;

        private AllServices _services = new AllServices();

        private void Awake()
        {
            RegisterServices();
            
            _exitHandler = new ExitHandler();
            
            _buttonBar.Construct(_services.Single<ISimpleInput>());
            _deviceBar.Construct(_services.Single<ISimpleInput>());
            
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
            _deviceBar.DeInitialize();
            
            InteractiveButton interactiveButton;
            
            if (_buttonBar.TryGetButton<StartGameButton>(out interactiveButton))
                interactiveButton.OnClicked -= LoadLevel;
            
            if (_buttonBar.TryGetButton<ExitButton>(out interactiveButton))
                interactiveButton.OnClicked -= Exit;
        }

        private void OnDestroy() => 
            DeInitialize();

        private void LoadLevel()
        {
            ISceneLoader sceneLoader = _services.Single<ISceneLoader>();
            sceneLoader.Load(SceneInfos.LEVEL);
        }

        private void Exit() => 
            _exitHandler.Exit();

        private void RegisterServices()
        {
            if(!_services.IsRegistered<ITickProcessor>())
                _services.RegisterSingle<ITickProcessor>(CreateTickProcessor());
            
            if(!_services.IsRegistered<ISimpleInput>())
                _services.RegisterSingle<ISimpleInput>(InputService());
        
            if(!_services.IsRegistered<ISceneLoader>())
                _services.RegisterSingle<ISceneLoader>(new SceneLoader());
        }

        private ITickProcessor CreateTickProcessor()
        {
            TickProcessor tickProcessor = new GameObject("TickProcessor").AddComponent<TickProcessor>();
            DontDestroyOnLoad(tickProcessor);

            return tickProcessor;
        }

        private ISimpleInput InputService()
        {
#if REWIRED_INPUT
        _log.text = "RewiredInput";
        return new RewiredInput();
#else
            _log.text = "UnityInput";
            return new UnityInput();
#endif
        }
    }
}