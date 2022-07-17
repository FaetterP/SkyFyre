using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Rider1Attack : AttackPattern
    {
        [SerializeField] private EnemyProjectile _enemyProjectile;

        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { SingleShot, SingleShot, SingleShot, SingleShot, SingleShot, SingleShot, SingleShot, SingleShot, SingleShot, CircleShot };

            base.Awake();
        }

        IEnumerator SingleShot(List<EnemyProjectile> list)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180)).Init(list, _damage, _speedProjectile);
            yield return new WaitForSeconds(0.2f);
        }

        IEnumerator CircleShot(List<EnemyProjectile> list)
        {
            for (int i = 0; i < 16; i++)
            {
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 22.5f * i)).Init(list, _damage, _speedProjectile);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
