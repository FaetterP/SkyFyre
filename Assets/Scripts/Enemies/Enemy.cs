using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Animator))]
    abstract class Enemy : Damageable
    {
        protected int _contactDamage;

        [SerializeField] private EnemyEndPoint _endPoint;
        private Animator _thisAnimator;
        
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
            Destroy(_endPoint.gameObject);
        }
    }
}
