using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawners
{
    class KamikazeSpawner : Spawner
    {
        private static System.Random rnd = new System.Random();

        public override void Spawn(Wave wave)
        {
            Vector2 position = new Vector2(rnd.Next(1000, 1100), rnd.Next(-300, 300));
            EnemyEndPoint spawned = Instantiate(_enemyEndPoint, position, Quaternion.identity);
            spawned.Init(wave);
        }
    }
}
