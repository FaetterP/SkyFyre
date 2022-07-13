using Assets.Scripts.Enemies.AttackPatterns;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Animator))]
    abstract class Enemy : Damageable
    {
        [SerializeField] protected int _contactDamage;
        [SerializeField] private AttackPattern[] _attackPatterns;
        [SerializeField] protected int _experience;
        protected Animator _thisAnimator;
        private EnemyArgumentFunction d_removeFromList;

        public int ContactDamage
        {
            get
            {
                return _contactDamage;
            }
        }

        protected void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
        }

        public void Init(EnemyArgumentFunction removeFromList)
        {
            d_removeFromList = removeFromList;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerProjectile projectile = collision.gameObject.GetComponent<PlayerProjectile>();
            if (projectile != null)
            {
                ApplyDamage(1);
                return;
            }
        }

        protected override void OnDamage()
        {
            _thisAnimator.SetBool("isDamaged", true);
            StartCoroutine(DisableAnimation());
        }

        IEnumerator DisableAnimation()
        {
            yield return new WaitForSeconds(0.05f);
            _thisAnimator.SetBool("isDamaged", false);
        }

        protected override void OnDeath()
        {
            foreach(AttackPattern gun in _attackPatterns)
            {
                gun.Destroy();
            }
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            d_removeFromList(this);
        }
    }
}
