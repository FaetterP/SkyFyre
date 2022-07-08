using Assets.Scripts.Enemies;
using UnityEngine;
using Assets.Scripts.Utils;
using System.Collections;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    class Character : Damageable
    {
        [SerializeField] private Transform _projectileSpawn;
        [SerializeField] private PlayerProjectile _projectile;
        private Animator _thisAnimator;

        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            _health = 80;
        }

        private void Update()
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = vec;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(_projectile, _projectileSpawn.position, Quaternion.identity);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EnemyProjectile projectile = collision.gameObject.GetComponent<EnemyProjectile>();
            if (projectile != null)
            {
                ApplyDamage(projectile.ContactDamage);
                return;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                ApplyDamage(enemy.ContactDamage);
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
            Destroy(gameObject);
        }
    }
}
