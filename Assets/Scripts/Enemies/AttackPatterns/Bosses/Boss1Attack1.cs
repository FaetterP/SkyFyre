using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Boss1Attack1 : AttackPattern
    {
        private Transform _characterTransform;

        private new void Awake()
        {
            _characterTransform = FindObjectOfType<Character>().transform;
            _attacks = new AttackCoroutine[] { Shot, Shot };

            base.Awake();
        }

        IEnumerator Shot(List<EnemyProjectile> list)
        {
            Vector3 angles = new Vector3(0,0, Vector2.Angle(Vector2.right, _characterTransform.position-transform.position));
            if (_characterTransform.position.y < transform.position.y)
            {
                angles *= -1;
            }
            angles -= new Vector3(0, 0, 10);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(angles)).Init(list, _damage, _speedProjectile);
            angles -= new Vector3(0, 0, 5);
            Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(angles)).Init(list, _damage, _speedProjectile);

            yield return new WaitForSeconds(0.3f);
        }
    }
}
