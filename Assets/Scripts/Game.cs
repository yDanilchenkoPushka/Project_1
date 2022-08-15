using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private SpawnPoint _spawnPoint;
        
        private Player _player;

        private bool HasPlayer => _player != null;

        private void Update()
        {
            if(HasPlayer)
                return;

            CheckSpawn();
        }

        private void CheckSpawn()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnPlayer();

        }

        private void SpawnPlayer()
        {
            Player playerPrefab = Resources.Load<Player>("Player");
            
            _player = Instantiate(playerPrefab);
            _player.Spawn(_spawnPoint.Position);
        }
    }
}