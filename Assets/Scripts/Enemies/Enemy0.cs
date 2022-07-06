using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Enemy0 : Enemy
    {
        private void Awake()
        {
            _health = 7;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(123);
            PlayerProjectile projectile = collision.gameObject.GetComponent<PlayerProjectile>();
            if (projectile == null) return;

            ApplyDamage(1);
        }

        protected override void OnDamage()
        {
            Debug.Log(_health);
        }

        protected override void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
