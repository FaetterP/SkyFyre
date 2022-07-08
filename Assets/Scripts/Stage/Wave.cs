using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    class Wave : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] _enemySpawners;
        private int _enemyCount;

        private void Awake()
        {
            _enemyCount = _enemySpawners.Length;
        }

        private void Start()
        {
            foreach(EnemySpawner spawner in _enemySpawners)
            {
                spawner.Spawn(this);
            }
        }

        public void DecreaseCount()
        {
            _enemyCount -= 1;
            if (_enemyCount <= 0)
            {
                Debug.Log("op");
                Destroy(gameObject);
            }
        }
    }
}
