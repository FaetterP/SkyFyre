using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Coroutines;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Triple : AttackPattern
    {
        [SerializeField] private EnemyProjectile _enemyProjectile;

        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { Attack0, Attack0, Attack0, Attack1 };

            base.Awake();
        }

        IEnumerator Attack0(List<EnemyProjectile> list)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 170)).Init(list);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180)).Init(list);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 190)).Init(list);
            //Debug.Log(list.Count);
            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator Attack1(List<EnemyProjectile> list)
        {
            yield return new WaitForSeconds(0.5f);
        }
    }
}
