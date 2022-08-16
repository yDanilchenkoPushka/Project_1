using CodeBase.Services;
using DefaultNamespace.Services.Input;
using UnityEngine;
using Rewired;
using Services.Input.Factory;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private SpawnPoint _spawnPoint;
        
        private SceneLoader _sceneLoader;
        
        private Player _player;

        private ISimpleInput _simpleInput;

        private bool HasPlayer => _player != null;

        private void Awake()
        {
            _simpleInput = AllServices.Container.Single<ISimpleInput>();

            _sceneLoader = new SceneLoader();

            _simpleInput.OnTaped += CreatePlayer;
        }
        
        private void OnDestroy()
        {
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