using DefaultNamespace.Services.Input;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private SpawnPoint _spawnPoint;
        
        private SceneLoader _sceneLoader;

        private InputService _inputService;
        private Player _player;

        private bool HasPlayer => _player != null;

        private void Awake()
        {
            _sceneLoader = new SceneLoader();
            _inputService = new InputService();
            
            _inputService.Initialize();

            _inputService.OnPlayed += CreatePlayer;
        }

        private void OnDestroy()
        {
            _inputService.DeInitialize();
        }

        private void CreatePlayer()
        {
            if (HasPlayer)
                return;
            
            Player playerPrefab = Resources.Load<Player>("Player");
            
            _player = Instantiate(playerPrefab);
            _player.Construct(_inputService);
            _player.Spawn(_spawnPoint.Position);

            _player.OnDamaged += KillPlayer;

            _inputService.OnPlayed -= CreatePlayer;
        }

        private void KillPlayer()
        {
            _player.OnDamaged -= KillPlayer;
            
            LoadMainMenu();
        }

        private void LoadMainMenu() => 
            _sceneLoader.Load(SceneInfos.MAIN_MENU);
    }
}