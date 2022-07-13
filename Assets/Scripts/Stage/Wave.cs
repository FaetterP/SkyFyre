using Assets.Scripts.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    class Wave : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;

        private void Start()
        {
            foreach (Enemy enemy in _enemies)
            {
                Enemy spawned = Instantiate(enemy);
                spawned.Init(RemoveFromList);
            }
        }

        private void RemoveFromList(Enemy enemy)
        {
            _enemies.Remove(enemy);

            if (_enemies.Count == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
