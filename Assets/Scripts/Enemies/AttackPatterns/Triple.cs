using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Triple : AttackPattern
    {
        [SerializeField] private EnemyProjectile _enemyProjectile;

        private void Awake()
        {
            _attacks = new Cor[] { Attack0, Attack0, Attack0, Attack1 };
        }

        IEnumerator Attack0()
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 170));
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180));
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 190));
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator Attack1()
        {
            yield return new WaitForSeconds(0.5f);
        }
    }
}
