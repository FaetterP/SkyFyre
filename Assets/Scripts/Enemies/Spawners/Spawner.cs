using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies.Spawners
{
    abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected EnemyEndPoint _enemyEndPoint;

        abstract public void Spawn(Wave wave);
    }
}
