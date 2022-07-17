using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class MiniBoss1Attack : AttackPattern
    {
        [SerializeField] private float _speedProjectileWide;

        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { NarrowShot, NarrowShot, NarrowShot, NarrowShot, NarrowShot, Pause, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, Pause };

            base.Awake();
        }

        IEnumerator NarrowShot(List<EnemyProjectile> list)
        {
            for (int i = -3; i <= 3; i++)
            {
                Vector3 angles = new Vector3(0, 0, 180 + i * (-10));
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(angles)).Init(list, _damage, _speedProjectile);
            }

            yield return new WaitForSeconds(0.3f);
        }

        IEnumerator Pause(List<EnemyProjectile> list)
        {
            yield return new WaitForSeconds(0.3f);
        }

        IEnumerator WideShot(List<EnemyProjectile> list)
        {
            for (int i = 0; i < 11; i++)
            {
                Vector3 angles = new Vector3(0, 0, 105 + 15 * i);
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(angles)).Init(list, _damage, _speedProjectileWide);
            }

            yield return new WaitForSeconds(0.3f);
        }
    }
}
