using Assets.Scripts.Enemies;
using Assets.Scripts.Gui;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    class Character : Damageable
    {
        [SerializeField] private Transform _projectileSpawn;
        [SerializeField] private PlayerProjectile _projectile;
        [SerializeField] private float _shotsPerSecond = 10;
        private Animator _thisAnimator;
        private TextCreator _textCreator;

        private float _delay;
        private float _currentDelay;

        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            _delay = 1 / _shotsPerSecond;
            _textCreator = FindObjectOfType<TextCreator>();
        }

        private void Update()
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = vec;

            if (_currentDelay > 0)
            {
                _currentDelay -= Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                _currentDelay = _delay;
                Instantiate(_projectile, _projectileSpawn.position, Quaternion.identity);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EnemyProjectile projectile = collision.gameObject.GetComponent<EnemyProjectile>();
            if (projectile != null)
            {
                _textCreator.Create(transform.position, projectile.ContactDamage);
                ApplyDamage(projectile.ContactDamage);
                return;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                _textCreator.Create(transform.position, enemy.ContactDamage);
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
