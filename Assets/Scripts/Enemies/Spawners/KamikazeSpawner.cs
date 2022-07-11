using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawners
{
    class KamikazeSpawner : Spawner
    {
        [SerializeField] private float _spawnX;
        private static System.Random rnd = new System.Random();

        public override void Spawn(Wave wave)
        {
            Vector2 position = new Vector2(_spawnX + rnd.Next(0, 100), rnd.Next(-300, 300));
            EnemyEndPoint spawned = Instantiate(_enemyEndPoint, position, Quaternion.identity);
            spawned.Init(wave);
        }
    }
}
