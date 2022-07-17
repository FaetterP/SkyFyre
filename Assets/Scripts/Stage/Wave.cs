using Assets.Scripts.Enemies;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Stage
{
    class Wave : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;
        private List<Enemy> _spawnedEnemies;
        private EmptyArgumentFunction _spawnNextWave;

        private void Awake()
        {
            _spawnedEnemies = new List<Enemy>();
        }

        public void Init(EmptyArgumentFunction spawnNextWave)
        {
            _spawnNextWave = spawnNextWave;
        }

        private void Start()
        {
            foreach (Enemy enemy in _enemies)
            {
                Enemy spawned = Instantiate(enemy);
                spawned.Init(RemoveFromList);
                _spawnedEnemies.Add(spawned);
            }
        }

        private void RemoveFromList(Enemy enemy)
        {
            _spawnedEnemies.Remove(enemy);

            if (_spawnedEnemies.Count == 0)
            {
                _spawnNextWave();
                Destroy(gameObject);
            }
        }
    }
}
