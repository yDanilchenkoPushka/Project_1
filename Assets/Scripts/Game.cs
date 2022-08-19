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

    private Player _player;
    private CubeSpawner _cubeSpawner;

    private ISceneLoader _sceneLoader;
    private ISimpleInput _simpleInput;

    private bool HasPlayer => _player != null;

    private void Awake()
    {
        _simpleInput = AllServices.Container.Single<ISimpleInput>();
        _sceneLoader = AllServices.Container.Single<ISceneLoader>();

        _cubeSpawnArea.Initialize();
            
        _cubeSpawner = new CubeSpawner(_cubeSpawnArea, _damageZones, this);
        _cubeSpawner.Initialize();
        
        _deviceBar.Construct(_simpleInput);
        _tipsBar.Construct(_simpleInput);

        _simpleInput.OnTaped += CreatePlayer;
    }
        
    private void OnDestroy()
    {
        _deviceBar.DeInitialize();
        _tipsBar.DeInitialize();

        _simpleInput.OnTaped -= CreatePlayer;
    }

    private void CreatePlayer()
    {
        if (HasPlayer)
            return;
            
        Player playerPrefab = Resources.Load<Player>("Player");
            
        _player = Instantiate(playerPrefab);
        _player.Construct(_simpleInput);
        _player.Spawn(_spawnPoint.Position);
            
        _player.OnDamaged += KillPlayer;
            
        _simpleInput.OnTaped -= CreatePlayer;
            
        _scoreBar.Construct(_player);
        _tipsBar.Initialize(_player);
    }

    private void KillPlayer()
    {
        _scoreBar.DeInitialize();
            
        _player.OnDamaged -= KillPlayer;
            
        LoadMainMenu();
    }

    private void LoadMainMenu() => 
        _sceneLoader.Load(SceneInfos.MAIN_MENU);
}