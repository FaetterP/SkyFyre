using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Boss1Attack2 : AttackPattern
    {
        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { Shot };

            base.Awake();
        }

        IEnumerator Shot(List<EnemyProjectile> list)
        {

            for (int i = 0; i < 5; i++)
            {
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180 - 20 * i)).Init(list, _damage, _speedProjectile);
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 270 + 20 * i)).Init(list, _damage, _speedProjectile);
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 80 - 20 * i)).Init(list, _damage, _speedProjectile);
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180 + 20 * i)).Init(list, _damage, _speedProjectile);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
