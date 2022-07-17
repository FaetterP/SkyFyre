using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    class Imp1Attack : AttackPattern
    {
        private new void Awake()
        {
            _attacks = new AttackCoroutine[] { Shot, Shot, Pause };

            base.Awake();
        }

        IEnumerator Shot(List<EnemyProjectile> list)
        {
            for (int i = 0; i < 4; i++)
            {
                Vector3 angles = new Vector3(0, 0, 150 + i * (20));
                Instantiate(_enemyProjectile, transform.position, Quaternion.Euler(angles)).Init(list, _damage, _speedProjectile);
            }

            yield return new WaitForSeconds(0.3f);
        }   
        
        IEnumerator Pause(List<EnemyProjectile> list)
        {
            yield return new WaitForSeconds(0.2f);
        }
    }
}
