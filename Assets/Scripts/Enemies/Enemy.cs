using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    abstract class Enemy : Damageable
    {
        [SerializeField] private Sprite _sprite;

        private void OnCollisionEnter2D(Collision2D collision)
        {
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
