using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class MiniBoss1Attack : AttackPattern
    {
        [SerializeField] private float _speedProjectileWide;
        [SerializeField] private EnemyProjectile _enemyProjectile;

        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { NarrowShot, NarrowShot, NarrowShot, NarrowShot, NarrowShot, Pause, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, WideShot, Pause };

            base.Awake();
        }

        IEnumerator NarrowShot(List<EnemyProjectile> list)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 150)).Init(list, _damage, _speedProjectile);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 160)).Init(list, _damage, _speedProjectile);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 170)).Init(list, _damage, _speedProjectile);

            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 180)).Init(list, _damage, _speedProjectile);

            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 190)).Init(list, _damage, _speedProjectile);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 200)).Init(list, _damage, _speedProjectile);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 210)).Init(list, _damage, _speedProjectile);
            yield return new WaitForSeconds(0.3f);
        }

        IEnumerator Pause(List<EnemyProjectile> list)
        {
            yield return new WaitForSeconds(0.3f);
        }

        IEnumerator WideShot(List<EnemyProjectile> list)
        {
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 15 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 30 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 45 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 60 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 75 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 90 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 105 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 120 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 135 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 150 + 90)).Init(list, _damage, _speedProjectileWide);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(0, 0, 165 + 90)).Init(list, _damage, _speedProjectileWide);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
