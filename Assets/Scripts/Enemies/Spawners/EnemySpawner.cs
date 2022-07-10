using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawners
{
    class EnemySpawner : Spawner
    {
        [SerializeField] private Vector2 _position;

        public override void Spawn(Wave wave)
        {
            EnemyEndPoint spawned = Instantiate(_enemyEndPoint, _position, Quaternion.identity);
            spawned.Init(wave);
        }
    }
}
