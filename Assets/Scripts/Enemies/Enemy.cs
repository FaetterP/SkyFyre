using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Animator))]
    abstract class Enemy : Damageable
    {
        private Animator _thisAnimator;

        protected void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            Debug.Log(_thisAnimator == null);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerProjectile projectile = collision.gameObject.GetComponent<PlayerProjectile>();
            if (projectile == null) return;

            ApplyDamage(1);
        }

        protected override void OnDamage()
        {
            Debug.Log(_health);
            
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
            Destroy(gameObject);
        }
    }
}
