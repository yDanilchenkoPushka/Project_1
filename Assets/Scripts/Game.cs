using Cube.Picked.Spawner;
using Damage;
using Data;
using DefaultNamespace;
using Services;
using Services.Input;
using Services.Scene;
using UI.Bars;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private SpawnPoint _spawnPoint;

    [SerializeField]
    private CubeSpawnArea _cubeSpawnArea;

    [SerializeField]
    private DamageZone[] _damageZones;

    [SerializeField]
    private ScoreBar _scoreBar;

    [SerializeField]
    private DeviceBar _deviceBar;

    [SerializeField]
    private TipsBar _tipsBar;

    [SerializeField]
    private Door _door;

    [SerializeField]
    private Camera _camera;

    private PlayerController _playerController;
    private CubeSpawner _cubeSpawner;
    private ISceneLoader _sceneLoader;
    private ISimpleInput _simpleInput;

    private bool HasPlayer => _playerController != null;

    private void Awake()
    {
        _simpleInput = AllServices.Container.Single<ISimpleInput>();
        _sceneLoader = AllServices.Container.Single<ISceneLoader>();

        _cubeSpawnArea.Initialize();
            
        _cubeSpawner = new CubeSpawner(_cubeSpawnArea, _damageZones, this);
        _cubeSpawner.Initialize();
        
        _deviceBar.Construct(_simpleInput);
        _tipsBar.Construct(_simpleInput, _camera);

        _simpleInput.OnTaped += CreatePlayer;

        _door.OnStateChanged += OnDoorStateChanged;
    }

    private void OnDestroy()
    {
        _deviceBar.DeInitialize();
        _tipsBar.DeInitialize();

        _simpleInput.OnTaped -= CreatePlayer;
        
        _door.OnStateChanged -= OnDoorStateChanged;
    }

    private void Update() => 
        _tipsBar.Tick();

    private void CreatePlayer()
    {
        if (HasPlayer)
            return;
            
        PlayerController playerControllerPrefab = Resources.Load<PlayerController>("Player");
            
        _playerController = Instantiate(playerControllerPrefab);
        _playerController.Construct(_simpleInput);
        _playerController.Spawn(_spawnPoint.Position);
            
        _playerController.OnDamaged += KillPlayerController;
            
        _simpleInput.OnTaped -= CreatePlayer;
            
        _scoreBar.Construct(_playerController);
        _tipsBar.Initialize(_playerController);
    }

    private void KillPlayerController()
    {
        _scoreBar.DeInitialize();
            
        _playerController.OnDamaged -= KillPlayerController;
            
        LoadMainMenu();
    }

    private void LoadMainMenu() => 
        _sceneLoader.Load(SceneInfos.MAIN_MENU);

    private void OnDoorStateChanged(bool isOpened)
    {
        if (isOpened)
        {
            _sceneLoader.LoadAdditive(SceneInfos.LEVEL_2);

            _door.OnStateChanged -= OnDoorStateChanged;
        }
    }
}