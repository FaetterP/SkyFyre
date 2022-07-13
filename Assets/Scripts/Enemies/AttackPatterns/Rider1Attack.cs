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
            _attacks = new AttackCoroutine[] { SingleShot, Pause };

            base.Awake();
        }

        IEnumerator SingleShot(List<EnemyProjectile> list)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180)).Init(list);
            yield return new WaitForSeconds(0.3f);
        }

        IEnumerator Pause(List<EnemyProjectile> list)
        {
            yield return new WaitForSeconds(0.3f);
        }
    }
}
