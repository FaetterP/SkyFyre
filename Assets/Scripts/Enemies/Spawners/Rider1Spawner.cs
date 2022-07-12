using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawners
{
    class Rider1Spawner : Spawner
    {
        [SerializeField] [Range(1, 4)] private int _spawn;

        public override void Spawn(Wave wave)
        {
            Rider1EndPoint spawned = Instantiate(_enemyEndPoint, Vector2.zero, Quaternion.identity) as Rider1EndPoint;
            spawned.Init(wave, _spawn);
        }
    }
}
