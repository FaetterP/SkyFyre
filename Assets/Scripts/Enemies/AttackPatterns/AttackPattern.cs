using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    abstract class AttackPattern : MonoBehaviour
    {
        protected AttackCoroutine[] _attacks;
        protected int _damage;
        private List<EnemyProjectile> _projectiles;

        protected void Awake()
        {
            _projectiles = new List<EnemyProjectile>();
        }

        public void Init(int damage)
        {
            _damage = damage;
        }

        private void Start()
        {
            StartCoroutine(StartAttack());
        }

        IEnumerator StartAttack()
        {
            for (int i = 0; ; i = (i + 1) % _attacks.Length)
            {
                yield return _attacks[i](_projectiles);
            }
        }

        public void Destroy()
        {
            foreach (EnemyProjectile projectile in _projectiles)
            {
                projectile.DefeatDestroy();
            }
        }
    }
}
