using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyEndPoint _enemyEndPoint;
        [SerializeField] private Vector2 _position;


        public void Spawn(Wave wave)
        {
            EnemyEndPoint spawned = Instantiate(_enemyEndPoint, _position, Quaternion.identity);
            spawned.Init(wave);
        }
    }
}
