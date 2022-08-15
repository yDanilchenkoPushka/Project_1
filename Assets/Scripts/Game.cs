using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private SpawnPoint _spawnPoint;
        
        private SceneLoader _sceneLoader;
        
        private Player _player;

        private bool HasPlayer => _player != null;

        private void Awake()
        {
            _sceneLoader = new SceneLoader();
        }

        private void Update()
        {
            if(HasPlayer)
                return;

            CheckSpawn();
        }

        private void CheckSpawn()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                CreatePlayer();

        }

        private void CreatePlayer()
        {
            Player playerPrefab = Resources.Load<Player>("Player");
            
            _player = Instantiate(playerPrefab);
            _player.Spawn(_spawnPoint.Position);

            _player.OnDamaged += KillPlayer;
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